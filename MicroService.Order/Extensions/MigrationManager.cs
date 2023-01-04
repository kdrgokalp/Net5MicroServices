using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Order.Infrastructure.Data;

using System;

namespace MicroService.Order.Extensions
{
    public static class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope()) // Dependect injectionda çağrım yapabilmek için kullanıyoruz.
            {
                try
                {
                    var orderContext = scope.ServiceProvider.GetRequiredService<OrderContext>();
                    //Inmemoryde tablo yapısı bulunmamaktadır. Sql server provider olduğu için bu kısmı atlamayacak.
                    if (orderContext.Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
                        orderContext.Database.Migrate();
                    
                    OrderContextSeed.SeedAsync(orderContext).Wait();
                }
                catch (Exception ex)
                {

                    throw;
                }
            }

            return host;
        }
    }
}
