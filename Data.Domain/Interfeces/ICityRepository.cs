using Data.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Data.Domain.Interfeces
{
    public interface ICityRepository
    {
        IReadOnlyList<City> GetAll();
        City GetById(Guid id);
        City GetByName(string name);
    }
}
