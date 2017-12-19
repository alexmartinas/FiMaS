using AutoMapper;
using Data.Domain.Entities;
using Data.Domain.Interfeces;
using Microsoft.AspNetCore.Mvc;
using Presentation.DTOs.ProductModels;
using System.Linq;

namespace Presentation.Controllers
{
    [Route("api/receipt/product")]
    public class ProductsController : Controller
    {
        private readonly IProductRepository _repository;

        public ProductsController(IProductRepository repository)
        {
            _repository = repository;
        }

        // POST api/receipt/products
        [HttpPost]
        public ActionResult Add([FromBody]CreateProductModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(400);
            }
            // create mapping between DTO and domain object
            var product = Mapper.Map<Product>(model);

            var newProduct =  _repository.AddProduct(product);
            if (newProduct == null)
            {
                return BadRequest(400);
            }
            return Ok(201);
        }

        [HttpGet]
        public ActionResult Get()
        {
            var products =  _repository.GetProducts();
            var results = products.Select(product => Mapper.Map<GetProductModel>(product)).ToList();
            return Ok(results);
        }

    }
}
