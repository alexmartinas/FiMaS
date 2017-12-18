using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Domain.Entities
{
    public class Receipt
    {
        [Key]
        public Guid ReceiptId { get; private set; }

        public Guid UserId { get; set; }
        public User User { get; private set; }
        
        [Required, DataType(DataType.DateTime)]
        public DateTime PrintedAt { get; private set; }
        
        public Guid ShopId { get; private set; }
        public Shop Shop { get; private set; }

        public List<Product> Products { get; private set; }

        public static Receipt Create(Guid userId, DateTime printedAt, Guid shopId)
        {
            return new Receipt
            {
                ReceiptId = new Guid(),
                UserId = userId,
                ShopId = shopId,
                PrintedAt = printedAt,
                Products = new List<Product>()
            };
        }

        public void Update(Guid userId, DateTime printedAt,Guid shopId)
        {
            UserId = userId;
            PrintedAt = printedAt;
            ShopId = shopId;
        }

    }
}
