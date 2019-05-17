using Microsoft.EntityFrameworkCore;

namespace AddressManager.Data
{
    public class CustomerDbContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAddress> CustomerAddresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=SQL18DEV;database=acuity_app;User Id=sa; Password=C3l5ius");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerAddress>().HasKey(c => new { c.AddrKey, c.CustKey });

            modelBuilder.Entity<CustomerAddress>()
                .HasOne(i => i.Address)
                .WithMany(e => e.CustomerAddresses)
                .HasForeignKey(ie => ie.AddrKey);

            modelBuilder.Entity<CustomerAddress>()
                .HasOne(g => g.Customer)
                .WithMany(r => r.CustomerAddresses)
                .HasForeignKey(o => o.CustKey);

            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Orders)
                .WithOne(k => k.Customer);

            modelBuilder.Entity<Order>().
                HasOne(c => c.Address)
                .WithMany(i => i.Orders);
        }
    }
}
