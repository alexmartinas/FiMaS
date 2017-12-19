using AutoMapper;
using Data.Domain.Entities;
using Data.Domain.Interfeces;
using Microsoft.AspNetCore.Mvc;
using Presentation.DTOs.ReceiptModel;
using System;
using System.Linq;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    public class ReceiptsController : Controller
    {
        private readonly IReceiptRepository _receiptRepository;
        private readonly IUserRepository _userRepository;
        private readonly IShopRepository _shopRepository;

        public ReceiptsController(IReceiptRepository receiptRepository, IUserRepository userRepository, IShopRepository shopRepository)
        {
            _receiptRepository = receiptRepository;
            _userRepository = userRepository;
            _shopRepository = shopRepository;
        }

        [HttpGet("{id:guid}")]
        public Receipt Get(Guid id)
        {
            return _receiptRepository.GetById(id);
        }

        [HttpGet]
        public IActionResult GetUserReceipt(Guid userId)
        {
            var receipts = _receiptRepository.GetReceiptsByOwner(userId);
            var result = receipts.Select(receipt => new GetReceiptModel
            {
                UserId = receipt.UserId,
                PrintedAt = receipt.PrintedAt,
                ReceiptId = receipt.ReceiptId,
                Shop = receipt.Shop
            })
                .ToList();
            return Ok(result);
        }
  

        [HttpPost]
        public IActionResult CreateReceipt([FromBody]CreateReceiptModel receiptModel)
        {
            if (receiptModel == null)
            {
                return BadRequest("Model is null");
            }

            var user = _userRepository.Get(receiptModel.UserId);
            if (user == null)
            {
                return NotFound("User not found");
            }
            var shop = _shopRepository.GetShopById(receiptModel.ShopId);
            if (shop == null)
            {
                return NotFound("Shop not found");
            }

            var receipt = Mapper.Map<Receipt>(receiptModel);
            _receiptRepository.CreateReceipt(receipt);
            return Ok();
        }
    }
}