using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Domain.Entities
{
    public class Country
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        //public IReadOnlyList<City> Cities { get; set; }
    }
}
