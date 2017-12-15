using System;
using System.Collections.Generic;

namespace Data.Domain.Interfeces
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        T Get(Guid id);
        List<T> GetAll();
        void Edit(T entity);
        void Delete(Guid id);
    }
}
