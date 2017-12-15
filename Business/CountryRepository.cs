using Data.Domain.Entities;
using Data.Domain.Interfeces;
using Data.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Business
{
    public class CountryRepository : ICountryRepository
    {
        private readonly IDatabaseContext _databaseContext;

        public CountryRepository(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IReadOnlyList<Country> GetAll()
        {
            return _databaseContext.Countries.ToList();
        }

        public Country GetById(Guid id)
        {
            return _databaseContext.Countries.FirstOrDefault(t => t.Id == id);
        }

        public Country GetByName(string name)
        {
            return _databaseContext.Countries
                .Include(c => c.Cities)
                .FirstOrDefault(t => t.Name.Equals(name));
        }
    }
}
