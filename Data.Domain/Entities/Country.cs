using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Domain.Entities
{
    public class Country
    {
        [Key]
        public Guid CountryId { get; private set; }

        [Required]
        public string Name { get; private set; }

        public List<City> Cities { get; private set; }

        public static Country Create(string name)
        {
            return new Country
            {
                CountryId = new Guid(),
                Name = name,
                Cities = new List<City>()
            };
        }
    }
}
