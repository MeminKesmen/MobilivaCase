using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Application.Repositories.Product
{
    public interface IProductReadRepository : IReadRepository<MobilivaCase.Domain.Entities.Product, int>
    {
    }
}
