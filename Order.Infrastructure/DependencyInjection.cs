using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Order.Domain.Repositories;
using Order.Infrastructure.Data;
using Order.Infrastructure.Repositories;
using Order.Infrastructure.Repositories.Base;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<OrderContext>(opt => opt.UseInMemoryDatabase(databaseName: "InMemoryDb"),
            //                                    ServiceLifetime.Singleton, //Order context life time
            //                                    ServiceLifetime.Singleton);//Optionların lifetime

            services.AddDbContext<OrderContext>(options =>
                        options.UseSqlServer(
                            configuration.GetConnectionString("OrderConnection"),
                            b => b.MigrationsAssembly(typeof(OrderContext).Assembly.FullName)), ServiceLifetime.Singleton); 

            //Add Repositories
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>)); //Base practis olarak tip alan kendi içerisinde interfaceleri life timeları eklerken bu şekildr ekliyoruz. T ifadesinden kaynaklı
            services.AddTransient<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}
