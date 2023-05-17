using Microsoft.Extensions.Hosting;
using MobilivaCase.Application.DTOs.RabbitMq;
using MobilivaCase.Application.Services;
using MobilivaCase.Application.Services.RabbitMqServices;
using MobilivaCase.Infrastructure.Services.RabbitMqServices;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RabbitMqBackgroundService
{
    public class Worker : BackgroundService
    {

        private readonly IRabbitMqClientService _rabbitMqClientService;
        readonly IMailService _mailService;
        private IModel _channel;
        public Worker(IRabbitMqClientService rabbitMqClientService, IMailService mailService)
        {

            _rabbitMqClientService = rabbitMqClientService;
            _mailService = mailService;
        }
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _channel = _rabbitMqClientService.Connect();
            _channel.BasicQos(0, 1, false);
            return base.StartAsync(cancellationToken);
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);
            _channel.BasicConsume(RabbitMqClientService.QueueName, true, consumer);
            consumer.Received += (s,e) => {
                var orderMail = JsonSerializer.Deserialize<OrderMailDto>(Encoding.UTF8.GetString(e.Body.ToArray()));
                Console.WriteLine(orderMail.CustomerEmail);
                _mailService.SendOrderInfo(orderMail);
            };
        }
    }
}
