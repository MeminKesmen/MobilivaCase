using Microsoft.Extensions.DependencyInjection;
using MobilivaCase.Application.Services;
using MobilivaCase.Application.Services.RabbitMqServices;
using MobilivaCase.Infrastructure.Services;
using MobilivaCase.Infrastructure.Services.RabbitMqServices;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IRedisCacheService, RedisCacheService>();
            services.AddSingleton(sp => new ConnectionFactory() { HostName = "localhost" });
            services.AddScoped<IRabbitMqClientService, RabbitMqClientService>();
            services.AddScoped<IRabbitMqOrderMailPublisher, RabbitMqOrderMailPublisher>();
            services.AddScoped<IMailService, MailService>();
        }

    }
}
