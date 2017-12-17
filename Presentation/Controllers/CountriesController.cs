using Data.Domain.Interfeces;
using Microsoft.AspNetCore.Mvc;
using Presentation.DTOs.CityModel;
using Presentation.DTOs.CountryModel;
using System;
using System.Collections.Generic;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    public class CountriesController : Controller
    {
        private readonly ICountryRepository _countryRepository;

        public CountriesController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        [HttpGet]
        public List<GetCountryModel> Get()
        {
            var entities = _countryRepository.GetAll();
            var getCountriesModel = new List<GetCountryModel>();

            foreach (var country in entities) {
                var countryModel = new GetCountryModel
                {
                    Name = country.Name
                };

                getCountriesModel.Add(countryModel);
            }

            return getCountriesModel;
        }
        [HttpGet("cities")]
        public List<GetCityModel> GetCities(string name)
        {
            var cities = _countryRepository.GetCountryCities(name);
            var getCitiesModel = new List<GetCityModel>();
            foreach (var city in cities)
            {
                var cityModel = new GetCityModel
                {
                    Name = city.Name
                };

                getCitiesModel.Add(cityModel);
            }
            return getCitiesModel ;
        }

        [HttpGet("{id:guid}")]
        public GetCountryModel Get(Guid id)
        {
            var entity = _countryRepository.GetById(id);
            var countryModel = new GetCountryModel
            {
                Name = entity.Name
            };
            return countryModel;
        }
    }
}