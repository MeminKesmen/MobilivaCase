using MobilivaCase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Application.Repositories
{
    public interface IWriteRepository<T, TKey> : IRepository<T, TKey> where T : BaseEntity<TKey>
    {
        Task<bool> AddAsync(T model);
        Task<bool> RemoveAsync(int id);
        Task<bool> UpdateAsync(T model);
        Task<bool> AddRangeAsync(List<T> datas);
        Task<int> SaveAsync();
    }
}
