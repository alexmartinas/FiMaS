using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Domain.Entities
{
    public class City
    {
        [Key]
        public Guid CityId { get; private set; }

        [Required]
        public string Name { get; private set; }

        public Guid CountryId { get; set; }
        public Country Country { get; private set; }

        public List<User> Users { get; private set; }
        public List<Shop> Shops { get; private set; }

        public static City Create(string name, Country country)
        {
            return new City
            {
                CityId = new Guid(),
                Name = name,
                Country = country,
                Users = new List<User>(),
                Shops = new List<Shop>()
            };
        }
    }
}
