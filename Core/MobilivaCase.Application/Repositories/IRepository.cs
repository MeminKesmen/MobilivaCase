using Microsoft.EntityFrameworkCore;
using MobilivaCase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Application.Repositories
{
    public interface IRepository<T, TKey> where T : BaseEntity<TKey>
    {
        DbSet<T> Table { get; }
    }
}
