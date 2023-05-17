using MobilivaCase.Application.Repositories.Order;
using MobilivaCase.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Persistence.Repositories.Order
{
    public class OrderReadRepository : ReadRepository<MobilivaCase.Domain.Entities.Order, int>, IOrderReadRepository
    {
        public OrderReadRepository(MobilivaDbContext context) : base(context)
        {
        }
    }
}
