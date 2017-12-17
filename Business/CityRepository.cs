using Data.Domain.Entities;
using Data.Domain.Interfeces;
using Data.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class CityRepository : ICityRepository
    {
        private readonly IDatabaseContext _databaseContext;

        public CityRepository(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IReadOnlyList<City> GetAll()
        {
            return _databaseContext.Cities.ToList();
        }

        public City GetById(Guid id)
        {
            return _databaseContext.Cities.FirstOrDefault(t => t.CityId == id);
        }

        public City GetByName(string name)
        {
            return _databaseContext.Cities.FirstOrDefault(t => t.Name.Equals(name));
        }
    }
}
