using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Domain.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; private set; }

        [Required]
        [MinLength(3)]
        [MaxLength(32)]
        public string Name { get; private set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; private set; }

        [Required]
        [MinLength(8)]
        [MaxLength(32)]
        public string Password { get; private set; }

        [Required]
        public Country Country { get; private set; }

        [Required]
        public City City { get; private set; }

        public static User Create(string name, string email, string password, Country idCountry, City idCity)
        {
            var instance = new User { Id = Guid.NewGuid() };
            instance.Update(name, email, password, idCountry, idCity);
            return instance;
        }

        public void Update(string name, string email, string password, Country country, City city)
        {
            this.Name = name;
            this.Email = email;
            this.Password = password;
            this.Country = country;
            this.City = city;
        }
    }
}
