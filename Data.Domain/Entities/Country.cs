using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Domain.Entities
{
    public class Country
    {
        public Guid Id { get; private set; }

        [Required]
        public string Name { get; private set; }

        public List<City> Cities { get; private set; }
        public List<User> Users { get; private set; }
        public List<Shop> Shops { get; private set; }

        public static Country Create(string name)
        {
            return new Country
            {
                Id = new Guid(),
                Name = name,
                Cities = new List<City>(),
                Users = new List<User>(),
                Shops = new List<Shop>()
            };
        }
    }
}
