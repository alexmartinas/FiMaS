using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Domain.Entities
{
    public class Shop
    {
        [Key]
        public Guid ShopId { get; private set; }

        [Required, MinLength(3), MaxLength(32)]
        public string Name { get; private set; }
        
        [Required]
        public string Address { get; private set; }

        public Guid CityId { get; set; }
        public City City { get; private set; }

        public List<Product> Products { get; private set; }


        public static Shop Create(string name, City city, string address)
        {
            return new Shop
            {
                ShopId = new Guid(),
                Name = name,
                City = city,
                Address = address,
                Products = new List<Product>()
            };
        }
    }
}
