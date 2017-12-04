using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.DTOs
{
    public class CreateUserModel
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        // TODO
        // public Guid IdCountry { get; set; }

        // TODO
        // public Guid IdCity { get; set; }
    }
}
