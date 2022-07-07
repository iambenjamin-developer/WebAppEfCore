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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasKey(x => x.Id);

            modelBuilder.Entity<Product>()
                        .Property(n => n.Name)
                        .IsRequired()
                        .HasMaxLength(99);

            modelBuilder.Entity<Product>()
                        .Property(n => n.UpdatedDate)
                        .IsConcurrencyToken();

            modelBuilder.Entity<Product>()
                        .Property(n => n.Stock)
                        .IsRequired();
        }
    }
}
