using Data.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation.DTOs.ReceiptModel
{
    public class CreateReceiptModel
    {
        public Guid UserId { get; set; }
        public DateTime PrintedAt { get; set; }
        public Guid ShopId { get; set; }
    }
}
