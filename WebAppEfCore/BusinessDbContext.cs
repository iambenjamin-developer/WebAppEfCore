using Microsoft.EntityFrameworkCore;
using WebAppEfCore.Entities;

namespace WebAppEfCore
{
    public class BusinessDbContext : DbContext
    {
        public BusinessDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Product> Products { get; set; }
    }
}
