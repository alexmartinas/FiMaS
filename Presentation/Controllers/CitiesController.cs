using Data.Domain.Entities;
using Data.Domain.Interfeces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    public class CitiesController : Controller
    {
        private readonly ICityRepository _repository;

        public CitiesController(ICityRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<City> Get()
        {
            return _repository.GetAll();
        }

        [HttpGet("{id:guid}")]
        public City Get(Guid id)
        {
            return _repository.GetById(id);
        }
    }
}