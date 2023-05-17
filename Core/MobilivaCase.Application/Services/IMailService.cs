using MobilivaCase.Application.DTOs.RabbitMq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Application.Services
{
    public interface IMailService
    {
        bool SendOrderInfo(OrderMailDto orderMailDto);
    }
}
