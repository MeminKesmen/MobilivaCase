using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Application.DTOs.RabbitMq
{
    public class OrderMailDto
    {
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public List<OrderMailDetailDto> OrderDetails { get; set; }
    }
}
