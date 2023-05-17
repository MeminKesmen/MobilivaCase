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
    public class Workerr 
    {
        public static string ExchangeName = "SendMailDirectExchange";
        public static string RoutingName = "SendMailRoute";
        public static string QueueName = "SendMailQueue";
        private readonly ConnectionFactory _connectionFactory;
        private IConnection _connection;
        private IModel _channel;
        //readonly IMailService _mailService;
        

        public Workerr ()
        {
            _connectionFactory = new ConnectionFactory() { HostName = "localhost" };
            _connection = _connectionFactory.CreateConnection();
            
            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare(ExchangeName, ExchangeType.Direct, true, false);
            _channel.QueueDeclare(QueueName, true, false, false, null);
            _channel.QueueBind(QueueName, ExchangeName, RoutingName);
        }
        public void Run()
        {
            var consumer = new EventingBasicConsumer(_channel);
            _channel.BasicConsume(RabbitMqClientService.QueueName, true, consumer);
            consumer.Received += (s,e) => {
                Console.WriteLine("resul");
                var orderMail = JsonSerializer.Deserialize<OrderMailDto>(Encoding.UTF8.GetString(e.Body.ToArray()));
                Console.WriteLine("result: ");
                Console.WriteLine(orderMail.CustomerEmail);
            };
        }
    }
}
