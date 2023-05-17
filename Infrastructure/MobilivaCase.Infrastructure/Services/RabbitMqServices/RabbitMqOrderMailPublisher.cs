using MobilivaCase.Application.DTOs.RabbitMq;
using MobilivaCase.Application.Services.RabbitMqServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MobilivaCase.Infrastructure.Services.RabbitMqServices
{
    public class RabbitMqOrderMailPublisher: IRabbitMqOrderMailPublisher
    {
        private readonly IRabbitMqClientService _rabbitMqClientService;
        public RabbitMqOrderMailPublisher(IRabbitMqClientService rabbitMqClientService)
        {
            _rabbitMqClientService = rabbitMqClientService;
        }

        public void Publish(OrderMailDto orderMailDto)
        {
            var channel = _rabbitMqClientService.Connect();
            var bodyString = JsonSerializer.Serialize(orderMailDto);
            var bodyByte = Encoding.UTF8.GetBytes(bodyString);
            var properties = channel.CreateBasicProperties();
            properties.Persistent = true;
            channel.BasicPublish(RabbitMqClientService.ExchangeName, RabbitMqClientService.RoutingName,true,properties,bodyByte);
        }
    }
}
