using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Domain.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(32)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(32)]
        public string Password { get; set; }

        [Required]
        public Guid IdCountry { get; set; }

        [Required]
        public Guid IdCity { get; set; }

        public static User Create(string name, string email, string password, Guid idCountry, Guid idCity)
        {
            var instance = new User { Id = Guid.NewGuid() };
            instance.Update(name, email, password, idCountry, idCity);
            return instance;
        }

        public void Update(string name, string email, string password, Guid idCountry, Guid idCity)
        {
            this.Name = name;
            this.Email = email;
            this.Password = password;
            this.IdCountry = idCountry;
            this.IdCity = idCity;
        }
    }
}
