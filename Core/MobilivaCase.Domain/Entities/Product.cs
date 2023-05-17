using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Domain.Entities
{
    public class Product:BaseEntity<int>
    {
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string Unit { get; set; }
        public decimal UnitPrice { get; set; }
        public bool Status { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime UpdateDate { get; set; } = DateTime.Now;

        public Category Category { get; set; }
        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }

}
