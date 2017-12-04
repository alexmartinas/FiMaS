using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Domain.Entities
{
    public class City
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

    }
}
