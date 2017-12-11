using Data.Domain.Entities;
using Data.Domain.Interfeces;
using Microsoft.AspNetCore.Mvc;
using Presentation.DTOs;
using System;
using System.Collections.Generic;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserRepository _repository;

        public UsersController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _repository.GetAll();
        }

        [HttpGet("{id:guid}")]
        public User Get(Guid id)
        {
            return _repository.GetById(id);
        }

        /*
        [HttpPost]
        public void Post([FromBody]CreateUserModel user)
        {
            var country = Guid.NewGuid(); // TODO
            var city = Guid.NewGuid();    // TODO

            var entity = Data.Domain.Entities.User.Create(user.Name, user.Email, user.Password, idCountry, idCity);
            _repository.Add(entity);
        }

        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody]UpdateUserModel user)
        {
            var entity = _repository.GetById(id);
            entity.Update(user.Name, user.Email, user.Password, user.IdCountry, user.IdCity);
            _repository.Edit(entity);
        }
        */

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _repository.Delete(id);
        }
    }
}