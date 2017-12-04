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
        private readonly ICountryRepository _countryRepository;
        private readonly ICityRepository _cityRepository;

        public UsersController (
            IUserRepository repository, 
            ICountryRepository countryRepository,
            ICityRepository cityRepository
            )
        {
            _repository = repository;
            //_countryRepository = countryRepository;
            //_cityRepository = cityRepository;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _repository.GetAll();
        }

        [HttpGet("{id:guid}")]
        public User Get(Guid id)
        {
            var entity = _repository.GetById(id);
            //var userModel = new GetUserModel {
            //    Name = entity.Name,
            //    Email = entity.Email,
            //    Country = entity.Country.Name,
            //    City = entity.City.Name
            //};
            return entity;
        }

        [HttpPost]
        public void Post([FromBody]CreateUserModel user)
        {
            //TODO
            var country = new Country
            {
                Id = Guid.NewGuid(),
                Name = user.Name
            };
            //TODO
            var city = new City
            {
                Id = Guid.NewGuid(),
                Name = user.City
            };

            var entity = Data.Domain.Entities.User.Create(user.Name, user.Email, user.Password, country, city);
            _repository.Add(entity);
        }

        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody]UpdateUserModel user)
        {
            var entity = _repository.GetById(id);
            //var country = _countryRepository.GetByName(user.Country);
            //var city = _cityRepository.GetByName(user.City);
            //TODO
            var country = new Country
            {
                Id = Guid.NewGuid(),
                Name = user.Name
            };
            //TODO
            var city = new City
            {
                Id = Guid.NewGuid(),
                Name = user.City
            };

            entity.Update(user.Name, user.Email, user.Password, country, city);
            _repository.Edit(entity);
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _repository.Delete(id);
        }
    }
}