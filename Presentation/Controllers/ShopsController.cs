using System;
using System.Collections.Generic;
using Data.Domain.Entities;
using Data.Domain.Interfeces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/shops")]
    public class ShopsController : Controller
    {
        private readonly IShopRepository _repository;

        public ShopsController(IShopRepository shopRepository)
        {
            _repository = shopRepository;
        }

        [HttpGet]
        public IEnumerable<Shop> GetAllShops()
        {
            return _repository.GetAllShops();
        }

        [HttpGet("{id}")]
        public Shop GetShop(Guid id)
        {
            return _repository.GetById(id);
        }

        [HttpGet("city/{id}")]
        public IEnumerable<Shop> GetAllShopsFromCity(Guid id)
        {
            return _repository.GetShopsByCity(id);
        }

        [HttpPost("city/{cityId}")]
        public IActionResult Post(Guid cityId, [FromBody]Shop shop)
        {
            City c = new City("Bacau", new Country("Romania"), new List<User>());
            Shop entity = new Shop(shop.Name, new Country("Romania"), c, shop.Address);

            _repository.Add(cityId, entity);
            return Ok(shop);
        }
    }
}
