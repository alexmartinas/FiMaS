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
            if (country == null) return cities;
            cities.Add(City.Create("Alba", country.CountryId));
            cities.Add(City.Create("Arad", country.CountryId));
            cities.Add(City.Create("Arges", country.CountryId));
            cities.Add(City.Create("Bacau", country.CountryId));
            cities.Add(City.Create("Bihor", country.CountryId));
            cities.Add(City.Create("Botosani", country.CountryId));
            cities.Add(City.Create("Brasov", country.CountryId));
            cities.Add(City.Create("Buzau", country.CountryId));
            cities.Add(City.Create("Caras-Severin", country.CountryId));
            cities.Add(City.Create("Calarasi", country.CountryId));
            cities.Add(City.Create("Cluj", country.CountryId));
            cities.Add(City.Create("Constanta", country.CountryId));
            cities.Add(City.Create("Covasna", country.CountryId));
            cities.Add(City.Create("Dambovita", country.CountryId));
            cities.Add(City.Create("Dolj", country.CountryId));
            cities.Add(City.Create("Gorj", country.CountryId));
            cities.Add(City.Create("Harghita", country.CountryId));
            cities.Add(City.Create("Hunedoara", country.CountryId));
            cities.Add(City.Create("Ialomita", country.CountryId));
            cities.Add(City.Create("Iasi", country.CountryId));
            cities.Add(City.Create("Ilfov", country.CountryId));
            cities.Add(City.Create("Maramures", country.CountryId));
            cities.Add(City.Create("Mehedinti", country.CountryId));
            cities.Add(City.Create("Mures", country.CountryId));
            cities.Add(City.Create("Neamt", country.CountryId));
            cities.Add(City.Create("Olt", country.CountryId));
            cities.Add(City.Create("Prahova", country.CountryId));
            cities.Add(City.Create("Satu Mare", country.CountryId));
            cities.Add(City.Create("Sibiu", country.CountryId));
            cities.Add(City.Create("Suceava", country.CountryId));
            cities.Add(City.Create("Teleorman", country.CountryId));
            cities.Add(City.Create("Timis", country.CountryId));
            cities.Add(City.Create("Vaslui", country.CountryId));
            cities.Add(City.Create("Valcea", country.CountryId));
            cities.Add(City.Create("Vrancea", country.CountryId));
            return cities;
        }
    }
}
