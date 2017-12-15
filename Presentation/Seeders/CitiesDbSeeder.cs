using System.Collections.Generic;
using System.Linq;
using Data.Domain.Entities;
using Data.Persistence;


namespace Presentation.Seeders
{
    public class CitiesDbSeeder
    {
        private readonly IDatabaseContext _database;

        public CitiesDbSeeder(IDatabaseContext database)
        {
            _database = database;
        }

        public void Seed()
        {
            if (_database.Cities.Any()) return;
            if (!_database.Countries.Any()) return;

            var countries = _database.Countries.ToList();
            _database.Cities.AddRange(GetCities(countries));
            _database.SaveChanges();
        }

        private static IEnumerable<City> GetCities(IEnumerable<Country> countries)
        {
            var cities = new List<City>();
            // Romania
            var country = countries.FirstOrDefault(c => c.Name.Equals("Romania"));
            cities.Add(City.Create("Alba", country));
            cities.Add(City.Create("Arad", country));
            cities.Add(City.Create("Arges", country));
            cities.Add(City.Create("Bacau", country));
            cities.Add(City.Create("Bihor", country));
            cities.Add(City.Create("Botosani", country));
            cities.Add(City.Create("Brasov", country));
            cities.Add(City.Create("Buzau", country));
            cities.Add(City.Create("Caras-Severin", country));
            cities.Add(City.Create("Calarasi", country));
            cities.Add(City.Create("Cluj", country));
            cities.Add(City.Create("Constanta", country));
            cities.Add(City.Create("Covasna", country));
            cities.Add(City.Create("Dambovita", country));
            cities.Add(City.Create("Dolj", country));
            cities.Add(City.Create("Gorj", country));
            cities.Add(City.Create("Harghita", country));
            cities.Add(City.Create("Hunedoara", country));
            cities.Add(City.Create("Ialomita", country));
            cities.Add(City.Create("Iasi", country));
            cities.Add(City.Create("Ilfov", country));
            cities.Add(City.Create("Maramures", country));
            cities.Add(City.Create("Mehedinti", country));
            cities.Add(City.Create("Mures", country));
            cities.Add(City.Create("Neamt", country));
            cities.Add(City.Create("Olt", country));
            cities.Add(City.Create("Prahova", country));
            cities.Add(City.Create("Satu Mare", country));
            cities.Add(City.Create("Sibiu", country));
            cities.Add(City.Create("Suceava", country));
            cities.Add(City.Create("Teleorman", country));
            cities.Add(City.Create("Timis", country));
            cities.Add(City.Create("Vaslui", country));
            cities.Add(City.Create("Valcea", country));
            cities.Add(City.Create("Vrancea", country));
            return cities;
        }
    }
}
