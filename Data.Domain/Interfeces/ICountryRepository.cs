using Data.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Data.Domain.Interfeces
{
    public interface ICountryRepository
    {
        IReadOnlyList<Country> GetAll();
        Country GetById(Guid id);
        Country GetByName(string name);
        void Add(Country country);
    }
}
