using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Domain.Entities
{
    public class Product
    {
        [Key]
        public Guid ProductId { get; private set; }

        [Required, MinLength(3), MaxLength(32)]
        public string Name { get; private set; }

        [Required, MinLength(3), MaxLength(32)]
        public string Category { get; private set; }

        [Required]
        public double Price { get; private set; }

        [Required, DataType(DataType.DateTime)]
        public DateTime BoughtAt { get; private set; }

        [Required]
        public string Provider { get; private set; }

        [Required]
        public double Quantity { get; private set; }

        public Guid ShopId { get; set; }
        public Shop Shop { get; private set; }

        public Guid ReceiptId { get; set; }
        public Receipt Receipt { get; private set; }

        public static Product Create(string name, string category, double price, DateTime boughtAt, string provider,
            double quantity, Shop shop, Receipt receipt)
        {
            return new Product
            {
                ProductId = new Guid(),
                Name = name,
                Category = category,
                Price = price,
                BoughtAt = boughtAt,
                Provider = provider,
                Quantity = quantity,
                Shop = shop,
                Receipt = receipt
            };
        }
    }
}
