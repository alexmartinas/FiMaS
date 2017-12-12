using AutoMapper;
using Data.Domain.Entities;
using Data.Domain.Interfeces;
using Microsoft.AspNetCore.Mvc;
using Presentation.DTOs.ProductModels;
using System;
using System.Collections.Generic;
using System.Text;

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
        public ActionResult Add([FromBody]CreateProductModel product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(400);
            }
            // create mapping between DTO and domain object
            var prod = Mapper.Map<Product>(product);

            var newProduct =  _repository.AddProduct(prod);
            if (newProduct == null)
            {
                return BadRequest(400);
            }
            return Ok(201);
        }
    }
}
