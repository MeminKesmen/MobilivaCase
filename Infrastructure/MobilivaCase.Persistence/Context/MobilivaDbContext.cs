
using Microsoft.EntityFrameworkCore;
using MobilivaCase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Persistence.Context
{
    public class MobilivaDbContext:DbContext
    {
        public MobilivaDbContext(DbContextOptions<MobilivaDbContext> options) : base(options)
        {
            
        }
        
        public DbSet<Product> Products{ get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Category> Categories { get; set; }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
           
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
