using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Domain.Entities
{
    public class User
    {
        [Key]
        public Guid UserId { get; private set; }

        [Required, MinLength(3), MaxLength(32)]
        public string Name { get; private set; }

        [Required, DataType(DataType.EmailAddress), EmailAddress]
        public string Email { get; private set; }

        [Required, MinLength(8), MaxLength(32)]
        public string Password { get; private set; }
       
        public Guid CityId { get; set; }
        public City City { get; private set; }
        
        public List<Receipt> Receipts { get; private set; }

        public static User Create(string name, string email, string password, City city)
        {
            var instance = new User
            {
                UserId = Guid.NewGuid(),
                Receipts = new List<Receipt>()
            };
            instance.Update(name, email, password, city);
            return instance;
        }

        public void Update(string name, string email, string password, City city)
        {
            Name = name;
            Email = email;
            Password = password;
            City = city;
        }
    }
}
