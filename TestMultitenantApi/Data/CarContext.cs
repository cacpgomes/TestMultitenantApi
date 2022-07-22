using System;
using Finbuckle.MultiTenant;
using Finbuckle.MultiTenant.EntityFrameworkCore;
using Finbuckle.MultiTenant.Stores;
using Microsoft.EntityFrameworkCore;
using TestMultitenantApi.Model;

namespace TestMultitenantApi.Data
{
    public class CarContext : MultiTenantDbContext
    {
        public DbSet<Car> Cars { get; set; } = default!;

        public CarContext(ITenantInfo tenantInfo): base(tenantInfo)
        {

        }

        public CarContext(ITenantInfo tenantInfo, DbContextOptions<CarContext> options): base(tenantInfo, options)
        {

        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (TenantInfo.ConnectionString != null)
            {
                optionsBuilder.UseSqlServer(TenantInfo.ConnectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}

