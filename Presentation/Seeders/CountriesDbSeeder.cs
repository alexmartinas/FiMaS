using System.Collections.Generic;
using System.Linq;
using Data.Domain.Entities;
using Data.Persistence;

namespace Presentation.Seeders
{
    public class CountriesDbSeeder
    {
        private readonly IDatabaseContext _database;

        public CountriesDbSeeder(IDatabaseContext database)
        {
            _database = database;
        }

        public void Seed()
        {
                if (_database.Countries.Any()) return;
                
                _database.Countries.AddRange(GetCountries());
                _database.SaveChanges();
        }

        private static IEnumerable<Country> GetCountries()
        {
            return new List<Country>
            {
                Country.Create("Romania")
            };
        }
    }
}
