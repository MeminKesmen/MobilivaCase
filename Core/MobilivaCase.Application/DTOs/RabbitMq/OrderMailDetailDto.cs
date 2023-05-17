using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Application.DTOs.RabbitMq
{
    public class OrderMailDetailDto
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }

    }
}
