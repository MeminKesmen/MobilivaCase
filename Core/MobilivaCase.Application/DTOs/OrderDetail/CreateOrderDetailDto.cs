using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Application.DTOs.OrderDetail
{
    public class CreateOrderDetailDto
    {
        public int ProductId { get; set; }
        public int Amount { get; set; }

    }
}
