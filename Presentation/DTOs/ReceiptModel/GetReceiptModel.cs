using Data.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation.DTOs.ReceiptModel
{
    public class GetReceiptModel
    {
        public Guid ReceiptId { get; set; }

        public Guid UserId { get; set; }

        public DateTime PrintedAt { get; set; }

        public Shop Shop { get; set; }
    }
}
