using MobilivaCase.Application.Repositories.Product;
using MobilivaCase.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Persistence.Repositories.Product
{
    public class ProductWriteRepository : WriteRepository<MobilivaCase.Domain.Entities.Product, int>, IProductWriteRepository
    {
        public ProductWriteRepository(MobilivaDbContext context) : base(context)
        {
        }
    }
}
