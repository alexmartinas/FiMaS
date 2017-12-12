using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Domain.Entities
{
    public class City
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; private set; }

        public Country Country { get; private set; }
        public List<User> Users { get; private set; }
        public List<Shop> Shops { get; private set; }

    }
}
