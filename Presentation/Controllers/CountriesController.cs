using Data.Domain.Entities;
using Data.Domain.Interfeces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    public class CountriesController : Controller
    {
        private readonly ICountryRepository _repository;

        public CountriesController(ICountryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<Country> Get()
        {
            return _repository.GetAll();
        }

        [HttpGet("{id:guid}")]
        public Country Get(Guid id)
        {
            return _repository.GetById(id);
        }
    }
}