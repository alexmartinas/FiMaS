using Data.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Persistence
{
    public interface IDatabaseContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Shop> Shops { get; set; }

        int SaveChanges();
    }
}
