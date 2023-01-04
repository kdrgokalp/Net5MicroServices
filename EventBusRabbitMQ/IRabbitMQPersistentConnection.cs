using RabbitMQ.Client;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBusRabbitMQ
{
    public interface IRabbitMQPersistentConnection : IDisposable
    {
        public bool IsConnected { get; }

        //Bu metot tekrardan bağlanmamaızı sağlayacak.
        public bool TryConnect();
        
        //Bu metot sayesinde queıe management işlemlerimizi yapmamızı sağlamaktadır.
        IModel CreateModel();
    }
}
