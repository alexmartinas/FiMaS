using Data.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Persistence
{
    public interface IDatabaseContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Country> Countries { get; set; }
        DbSet<City> Cities { get; set; }

        int SaveChanges();
    }
}
