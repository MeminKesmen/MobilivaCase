using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Application.Repositories.Order
{
    public interface IOrderReadRepository:IReadRepository<MobilivaCase.Domain.Entities.Order,int>
    {
    }
}
