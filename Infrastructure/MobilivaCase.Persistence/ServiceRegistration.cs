using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MobilivaCase.Application.Repositories.Category;
using MobilivaCase.Application.Repositories.Order;
using MobilivaCase.Application.Repositories.OrderDetail;
using MobilivaCase.Application.Repositories.Product;
using MobilivaCase.Application.Services;
using MobilivaCase.Persistence.Context;
using MobilivaCase.Persistence.Repositories.Category;
using MobilivaCase.Persistence.Repositories.Order;
using MobilivaCase.Persistence.Repositories.OrderDetail;
using MobilivaCase.Persistence.Repositories.Product;
using MobilivaCase.Persistence.Services;


namespace MobilivaCase.Persistence
{
    public static class ServiceRegistration
    {

        public static void AddPersistenceServices(this IServiceCollection services)
        {
            var connString = Configuration.ConnectionString;
            services.AddDbContext<MobilivaDbContext>(options => options.UseMySQL(connString));
            


            #region Repositories
            services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<IOrderDetailReadRepository, OrderDetailReadRepository>();
            services.AddScoped<IOrderDetailWriteRepository, OrderDetailWriteRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();


            #endregion

            #region Services
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IProductService, ProductService>();

            #endregion
        }
    }
}
