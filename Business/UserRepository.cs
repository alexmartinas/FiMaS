using Data.Domain.Entities;
using Data.Domain.Interfeces;
using Data.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Business
{
    public class UserRepository : IUserRepository
    {
        private readonly IDatabaseContext _databaseContext;

        public UserRepository(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<User> GetAll()
        {
            return _databaseContext
                        .Users
                        .Include(t => t.City)
                            .ThenInclude(t => t.Country)
                        .ToList();
        }

        public void Add(User user)
        {
            _databaseContext.Users.Add(user);
            _databaseContext.SaveChanges();
        }

        public User Get(Guid id)
        {
            return _databaseContext
                        .Users
                        .Include(t => t.City)
                            .ThenInclude(t => t.Country)
                        .FirstOrDefault(t => t.UserId == id);
        }

        public void Delete(Guid id)
        {
            var user = Get(id);
            if (user == null) return;
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
