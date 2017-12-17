using System.Linq;
using Data.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Persistence
{
    public sealed class DatabaseContext : DbContext, IDatabaseContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shop> Shops { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // City 1 - * User
            modelBuilder.Entity<User>()
                .HasOne(t => t.City)
                .WithMany(t => t.Users)
                .HasForeignKey(t => t.CityId);

            //Country 1 - * City
            modelBuilder.Entity<City>()
                .HasOne(t => t.Country)
                .WithMany(t => t.Cities)
                .HasForeignKey(t => t.CountryId);

            // City 1 - * Shop
            modelBuilder.Entity<Shop>()
                .HasOne(t => t.City)
                .WithMany(t => t.Shops)
                .HasForeignKey(t => t.CityId);

            // User 1 - * Receipt
            modelBuilder.Entity<Receipt>()
                .HasOne(t => t.User)
                .WithMany(t => t.Receipts)
                .HasForeignKey(t => t.UserId);

            // Receipt 1 - * Product
            modelBuilder.Entity<Product>()
                .HasOne(t => t.Receipt)
                .WithMany(t => t.Products)
                .HasForeignKey(t => t.ReceiptId);

            // Shop 1 - * Product
            modelBuilder.Entity<Product>()
                .HasOne(t => t.Shop)
                .WithMany(t => t.Products)
                .HasForeignKey(t => t.ShopId);

            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(modelBuilder);
        }
    }
}
