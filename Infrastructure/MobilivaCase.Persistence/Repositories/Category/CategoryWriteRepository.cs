using MobilivaCase.Application.Repositories.Category;
using MobilivaCase.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Persistence.Repositories.Category
{
    public class CategoryWriteRepository : WriteRepository<MobilivaCase.Domain.Entities.Category, int>, ICategoryWriteRepository
    {
        public CategoryWriteRepository(MobilivaDbContext context) : base(context)
        {
        }
    }
}
