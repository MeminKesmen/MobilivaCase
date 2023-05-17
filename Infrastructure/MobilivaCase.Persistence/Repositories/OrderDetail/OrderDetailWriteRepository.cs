using MobilivaCase.Application.Repositories.OrderDetail;
using MobilivaCase.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Persistence.Repositories.OrderDetail
{
    public class OrderDetailWriteRepository : WriteRepository<MobilivaCase.Domain.Entities.OrderDetail, int>, IOrderDetailWriteRepository
    {
        public OrderDetailWriteRepository(MobilivaDbContext context) : base(context)
        {
        }
    }
}
