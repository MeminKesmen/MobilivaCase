using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Application.Services.RabbitMqServices
{
    public interface IRabbitMqClientService:IDisposable
    {
        IModel Connect();
    }
}
