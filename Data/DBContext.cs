using DummyCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace DummyCrud.Data
{
    public class DBContext:DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerWarranty>()
                .HasKey(c => c.ID);
            modelBuilder.Entity<CustomerWarranty>()
                .Property(c => c.ID)
                .ValueGeneratedOnAdd();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<CustomerWarranty> CustomerWarranties { get; set; }
    }
}
