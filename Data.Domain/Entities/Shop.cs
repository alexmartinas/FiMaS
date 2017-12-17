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

        public Guid CityId { get; private set; }
        public City City { get; set; }

        public List<Product> Products { get; private set; }

        public static Shop Create(string name, Guid cityId, string address)
        {
            return new Shop
            {
                ShopId = new Guid(),
                Name = name,
                CityId = cityId,
                Address = address,
                Products = new List<Product>()
            };
        }

        public void Update(string name, Guid cityId, string address)
        {
            Name = name;
            CityId = cityId;
            Address = address;
        }
    }
}
