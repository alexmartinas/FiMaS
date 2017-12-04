using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        [Required]
        [MinLength(3), MaxLength(32)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(8), MaxLength(32)]
        public string Password { get; set; }

        public Country Country { get; set; }

        public City City { get; set; }

        public static User Create(string name, string email, string password, Country country, City city)
        {
            var instance = new User { Id = Guid.NewGuid() };
            instance.Update(name, email, password, country, city);
            return instance;
        }

        public void Update(string name, string email, string password, Country coutry, City city)
        {
            this.Name = name;
            this.Email = email;
            this.Password = password;
            this.Country = coutry;
            this.City = city;
        }
    }
}
