using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MobilivaCase.Application.DTOs.RabbitMq;
using MobilivaCase.Infrastructure;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMqBackgroundService;
using System.Text;
using System.Text.Json;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddInfrastructureServices();
        services.AddHostedService<Worker>();

    })
    .Build();

await host.RunAsync();
