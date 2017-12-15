﻿using Data.Domain.Entities;
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
        public DbSet<Product> Products { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Shop> Shops { get; set; }
    }
}
