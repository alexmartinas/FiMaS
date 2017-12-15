using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Domain.Entities
{
    public class Product
    {
        [Key]
        public Guid Id { get; private set; }

        [Required]
        [MinLength(3)]
        [MaxLength(32)]
        public string Name { get; private set; }

        [Required]
        [MinLength(3)]
        [MaxLength(32)]
        public string Category { get; private set; }

        [Required]
        public double Price { get; private set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime BoughtAt { get; private set; }

        [Required]
        public string Provider { get; private set; }

        public Shop Shop { get; private set; }

        [Required]
        public double Quantity { get; private set; }

        public Receipt Receipt { get; private set; }

    }
}
