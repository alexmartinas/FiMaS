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
        
        public List<Product> Products { get; private set; }

        public static Receipt Create(User user, DateTime printedAt)
        {
            return new Receipt
            {
                ReceiptId = new Guid(),
                User = user,
                PrintedAt = printedAt,
                Products = new List<Product>()
            };
        }

    }
}
