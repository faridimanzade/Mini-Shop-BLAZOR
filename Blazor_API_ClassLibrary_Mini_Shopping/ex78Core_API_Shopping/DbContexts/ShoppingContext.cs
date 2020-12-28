using ex78Core_ClassLibrary_Shopping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ex78Core_API_Shopping.DbContexts
{
    public class ShoppingContext : DbContext
    {
        public ShoppingContext(DbContextOptions<ShoppingContext> dbContext)
            :base(dbContext)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
