using MicroService.Order.Consumers;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System;

namespace MicroService.Order.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        //Consumer singleton olarak ekledik lakin Consumer nesnesindeki consume metodunu çalıştırmamız gerektiği için bu sınıfı oluşturduk.
        public static EventBusOrderCreateConsumer Listener { get; set; }

        //Bir tane middleware extension yazmamız gerekiyor. Burada çalışması için extension metot geliştiriyoruz. Bunu sonradan configurede ayağa kaldırıacağız.
        //ApplicationBuilderExtensions geliştirdik
        //    Eventbusordercreateconsumer erişmek istedik.
        //    Bunuda yaparken uygulamayı ayağa kaldırırken uygulamanın life time'ın da start olduğunda stop olduğunda bu extension üzerinden
        //    Consumer başlatıp durdurarak yönetmek.
        public static IApplicationBuilder UseRabbitListener(this IApplicationBuilder app)
        {
            Listener = app.ApplicationServices.GetService<EventBusOrderCreateConsumer>();
            
            var life = app.ApplicationServices.GetService<IHostApplicationLifetime>();

            life.ApplicationStarted.Register(OnStarted);
            life.ApplicationStopping.Register(OnStoping);

            return app;
        }

        private static void OnStarted()
        {
            Listener.Consume();
        }

        private static void OnStoping()
        {
            Listener.Disconnect();
        }
    }
}
