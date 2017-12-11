using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Domain.Entities
{
    public class Shop
    {
        [Key]
        public Guid Id { get; private set; }

        [Required]
        [MinLength(3)]
        [MaxLength(32)]
        public string Name { get; private set; }

        [Required]
        public Country Country { get; private set; }
        [Required]
        public City City { get; private set; }

        [Required]
        public string Address { get; private set; }

        public List<Product> Products { get; private set; }
    }
}
