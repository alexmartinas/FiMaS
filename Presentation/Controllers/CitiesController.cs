using Data.Domain.Interfeces;
using Microsoft.AspNetCore.Mvc;
using Presentation.DTOs.CityModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    public class CitiesController : Controller
    {
        private readonly ICityRepository _cityRepository;
        private readonly ICountryRepository _countryRepository;

        public CitiesController(
            ICityRepository cityRepository,
            ICountryRepository countryRepository)
        {
            _cityRepository = cityRepository;
            _countryRepository = countryRepository;
        }

        [HttpGet]
        public List<GetCityModel> Get()
        {
            var entities = _cityRepository.GetAll();

            return entities.Select(city => new GetCityModel
                {
                    Name = city.Name
                })
                .ToList();
        }

        [Route("GetCitiesByCountry")]
        [HttpGet]
        public List<GetCityModel> Get(string countryName)
        {
            var country = _countryRepository.GetByName(countryName);

            return country.Cities.Select(city => new GetCityModel
                {
                    Name = city.Name
                })
                .ToList();
        }

        [HttpGet("{id:guid}")]
        public GetCityModel Get(Guid id)
        {
            var entity = _cityRepository.GetById(id);
            var cityModel = new GetCityModel
            {
                Name = entity.Name
            };
            return cityModel;
        }
    }
}