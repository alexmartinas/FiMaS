using Data.Domain.Interfeces;
using Microsoft.AspNetCore.Mvc;
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