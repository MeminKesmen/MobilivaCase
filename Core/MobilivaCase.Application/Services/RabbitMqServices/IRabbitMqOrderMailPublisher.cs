using MobilivaCase.Application.DTOs.RabbitMq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Application.Services.RabbitMqServices
{
    public interface IRabbitMqOrderMailPublisher
    {
        public void Publish(OrderMailDto orderMailDto);
    }
}
