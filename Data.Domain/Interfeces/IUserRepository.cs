using Data.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Data.Domain.Interfeces
{
    public interface IUserRepository
    {
        IReadOnlyList<User> GetAll();
        User GetById(Guid id);
        void Add(User user);
        void Edit(User user);
        void Delete(Guid id);
    }
}
