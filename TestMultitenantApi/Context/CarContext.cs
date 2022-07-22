using System;
using Microsoft.EntityFrameworkCore;
using TestMultitenantApi.Model;

namespace TestMultitenantApi.Context
{
    public class CarContext : DbContext
    {
        public DbSet<Car> Cars { get; set; } = default!;
        public CarContext()
        {
        }

        public CarContext(DbContextOptions<CarContext> options): base(options)
        {
            
        }
    }
}

