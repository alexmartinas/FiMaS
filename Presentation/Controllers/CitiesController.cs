using Data.Domain.Interfeces;
using Microsoft.AspNetCore.Mvc;
using Presentation.DTOs.CityModel;
using System;
using System.Collections.Generic;

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

            var getCitiesModel = new List<GetCityModel>();

            foreach (var city in entities)
            {
                var cityModel = new GetCityModel
                {
                    Name = city.Name
                };

                getCitiesModel.Add(cityModel);
            }

            return getCitiesModel;
        }

        [Route("GetCitiesByCountry")]
        [HttpGet]
        public List<GetCityModel> Get(string countryName)
        {
            var country = _countryRepository.GetByName(countryName);
            var getCitiesModel = new List<GetCityModel>();

            foreach (var city in country.Cities)
            {
                var cityModel = new GetCityModel
                {
                    Name = city.Name
                };

                getCitiesModel.Add(cityModel);
            }

            return getCitiesModel;
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