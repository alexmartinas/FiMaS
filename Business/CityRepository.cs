using Data.Domain.Entities;
using Data.Domain.Interfeces;
using Data.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Business
{
    public class CityRepository : ICityRepository
    {
        private readonly IDatabaseContext _databaseContext;

        public CityRepository(IDatabaseContext databaseContext) => _databaseContext = databaseContext;

        public IReadOnlyList<City> GetAll() => _databaseContext
                        .Cities
                        .ToList();

        public City GetById(Guid id) => _databaseContext
                        .Cities
                        .FirstOrDefault(t => t.CityId == id);

        public City GetByName(string name) => _databaseContext
                        .Cities
                        .Include(t => t.Shops)
                        .FirstOrDefault(t => t.Name.Equals(name));
    }
}
