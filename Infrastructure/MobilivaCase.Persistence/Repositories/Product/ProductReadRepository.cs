using MobilivaCase.Application.Repositories.Product;
using MobilivaCase.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Persistence.Repositories.Product
{
    public class ProductReadRepository : ReadRepository<MobilivaCase.Domain.Entities.Product, int>, IProductReadRepository
    {
        public ProductReadRepository(MobilivaDbContext context) : base(context)
        {
        }
    }
}
