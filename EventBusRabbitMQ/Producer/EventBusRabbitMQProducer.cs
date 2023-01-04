using EventBusRabbitMQ.Events.Interfaces;

using Microsoft.Extensions.Logging;

using Newtonsoft.Json;

using Polly;
using Polly.Retry;

using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EventBusRabbitMQ.Producer
{
    public class EventBusRabbitMQProducer
    {
        private readonly IRabbitMQPersistentConnection _persistentConnection;
        private readonly ILogger<EventBusRabbitMQProducer> _logger;
        private readonly int _retryCount;

        public EventBusRabbitMQProducer(IRabbitMQPersistentConnection persistentConnection, ILogger<EventBusRabbitMQProducer> loggger, int retryCount = 5)
        {
            _persistentConnection = persistentConnection;
            _logger = loggger;
            _retryCount = retryCount;
        }

        public void Publish(string queueName, IEvent @event)
        {
            if (!_persistentConnection.IsConnected)
            {
                _persistentConnection.TryConnect();
            }

            var policy = RetryPolicy.Handle<SocketException>()
                                .Or<BrokerUnreachableException>()
                                .WaitAndRetry(_retryCount, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)), (ex, time) =>
                                {
                                    _logger.LogWarning(ex, "RabbitMQ Client could not connect after {TimeOut}s ({ExceptionMessage})", $"{time.TotalSeconds:n1}", ex.Message);
                                });

            using (var channel = _persistentConnection.CreateModel())
            {
                //Declare edildi.
                //Basic bir implementasyon yapıldı.
                //queueName: queue ismi
                //Durable:Eğer false inmemory olarak kullanıyor. True olarak gönderdiğimizde sunucu içerisinde kalyor. 
                //Exclusive: Bu queue tek bir connection sahip olmasını sağlyor. Eğer bu değer true tek bir consumer connecte edebilir o consumerda silindiğinde connection kapanır. Kapandığında queue silineceğini söylüyor
                //autoDelete : eğer true olursa. Son connection subscribe olduğun queue silineceğini belirtyor
                //arguments: Queue bazı değerlere ulaşabilir.
                channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null); 
                var message = JsonConvert.SerializeObject(@event);
                var body = Encoding.UTF8.GetBytes(message);

                policy.Execute(() =>
                {
                    IBasicProperties properties = channel.CreateBasicProperties(); // Default propertyleri verir.
                    properties.Persistent = true; //
                    properties.DeliveryMode = 2; //

                    channel.ConfirmSelect();
                    channel.BasicPublish( //Açılan kanallar üzerinden basicpublish ile eventte queue mesaj bırakılr.
                        exchange: "", //Default 
                        routingKey: queueName,
                        mandatory: true,
                        basicProperties: properties,
                        body: body);
                    channel.WaitForConfirmsOrDie();
                    channel.BasicAcks += (sender, eventArgs) =>
                     {
                         Console.WriteLine("Sent RabbitMQ");
                     };
                });
            }
        }
    }
}
