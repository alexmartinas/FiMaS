using System;
using System.Collections.Generic;
using System.Linq;
using Data.Domain.Entities;
using Data.Domain.Interfeces;
using Microsoft.AspNetCore.Mvc;
using Presentation.DTOs.ShopModels;

namespace Presentation.Controllers
{
    [Route("api/shops")]
    public class ShopsController : Controller
    {
        private readonly IShopRepository _shopRepository;
        private readonly ICityRepository _cityRepository;

        public ShopsController(IShopRepository shopRepository, ICityRepository cityRepository)
        {
            _shopRepository = shopRepository;
            _cityRepository = cityRepository;
        }

        [HttpGet]
        public IEnumerable<GetShopModel> GetAllShops()
        {
            var entities = _shopRepository.GetAll();

            return entities.Select(shop => new GetShopModel
            {
                ShopId = shop.ShopId,
                Name = shop.Name,
                Address = shop.Address,
                City = shop.City.Name,
                Country = shop.City.Country.Name
            }).ToList();
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetShop(Guid id)
        {
            var shop = _shopRepository.Get(id);
            if (shop == null) return BadRequest();
            
            return Ok(new GetShopModel
            {
                ShopId = shop.ShopId,
                Name = shop.Name,
                Address = shop.Address,
                City = shop.City.Name,
                Country = shop.City.Country.Name
            });
        }

        [HttpGet("{city}")]
        public IEnumerable<GetShopModel> GetAllShopsFromCity(string city)
        {
            var entities = _shopRepository.GetShopsByCity(city);

            return entities.Select(shop => new GetShopModel
            {
                ShopId = shop.ShopId,
                Name = shop.Name,
                Address = shop.Address,
                City = shop.City.Name,
                Country = shop.City.Country.Name
            }).ToList();
        }

        [HttpPost]
        public IActionResult Post([FromBody]CreateShopModel shop)
        {
            var city = _cityRepository.GetByName(shop.City);
            var entity = Shop.Create(shop.Name, city.CityId, shop.Address);

            _shopRepository.Add(entity);
            return Ok(shop);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody]CreateShopModel shop)
        {
            var city = _cityRepository.GetByName(shop.City);
            var entity = _shopRepository.Get(id);

            entity.Update(shop.Name, city.CityId, shop.Address);
            _shopRepository.Edit(entity);
            return Ok(shop);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _shopRepository.Delete(id);
            return Ok();
        }
    }
}
