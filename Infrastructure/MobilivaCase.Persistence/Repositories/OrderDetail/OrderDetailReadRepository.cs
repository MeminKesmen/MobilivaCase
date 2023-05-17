using MobilivaCase.Application.Repositories.Order;
using MobilivaCase.Application.Repositories.OrderDetail;
using MobilivaCase.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Persistence.Repositories.OrderDetail
{
    public class OrderDetailReadRepository : ReadRepository<MobilivaCase.Domain.Entities.OrderDetail, int>, IOrderDetailReadRepository
    {
        public OrderDetailReadRepository(MobilivaDbContext context) : base(context)
        {
        }
    }
}
