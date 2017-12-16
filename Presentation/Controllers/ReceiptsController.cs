using Data.Domain.Entities;
using Data.Domain.Interfeces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    public class ReceiptsController : Controller
    {
        private readonly IReceiptRepository _repository;

        public ReceiptsController(IReceiptRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id:guid}")]
        public Receipt Get(Guid id)
        {
            return _repository.GetById(id);
        }
    }
}