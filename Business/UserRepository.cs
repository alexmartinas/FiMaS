using Data.Domain.Entities;
using Data.Domain.Interfeces;
using Data.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class UserRepository : IUserRepository
    {
        private readonly IDatabaseContext _databaseContext;

        public UserRepository(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IReadOnlyList<User> GetAll()
        {
            return _databaseContext.Users.ToList();
        }

        public void Add(User user)
        {
            _databaseContext.Users.Add(user);
            _databaseContext.SaveChanges();
        }

        public User GetById(Guid id)
        {
            return _databaseContext.Users.FirstOrDefault(t => t.Id == id);
        }

        public void Delete(Guid id)
        {
            var user = GetById(id);
            _databaseContext.Users.Remove(user);
            _databaseContext.SaveChanges();
        }

        public void Edit(User user)
        {
            _databaseContext.Users.Update(user);
            _databaseContext.SaveChanges();
        }
    }
}
