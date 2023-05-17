using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Domain.Entities
{
    public class Order:BaseEntity<int>
    {
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerGSM { get; set; }
        public int TotalAmount { get; set; }

        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }

}
