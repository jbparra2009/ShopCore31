using Microsoft.Extensions.DependencyInjection;
using ShopCore31.Application;
using ShopCore31.Database;
using ShopCore31.Domain.Infrastructure;
using ShopCore31.UI.Infrastructure;
using System.Linq;
using System.Reflection;

namespace ShopCore31.UI
{
    public static class ServiceRegister
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection @this)
        {
            var serviceType = typeof(Service);
            var definedTypes = serviceType.Assembly.DefinedTypes;

            var services = definedTypes
                .Where(x => x.GetTypeInfo().GetCustomAttribute<Service>() != null);

            foreach (var service in services)
            {
                @this.AddTransient(service);
            }

            @this.AddTransient<IStockManager, StockManager>();
            @this.AddTransient<IProductManager, ProductManager>();
            @this.AddTransient<IOrderManager, OrderManager>();
            @this.AddScoped<ISessionManager, SessionManager>();

            return @this;
        }
    }
}
