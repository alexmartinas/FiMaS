using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Domain.Entities
{
    public class Receipt
    {
        [Key]
        public Guid Id { get; private set; }

        [Required]
        public User User { get; private set; }

        [Required]
        public IReadOnlyList<Product> Products { get; private set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime PrintedAt { get; private set; } 

    }
}
