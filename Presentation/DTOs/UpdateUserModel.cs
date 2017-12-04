using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.DTOs
{
    public class UpdateUserModel
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public Guid IdCountry { get; set; }

        public Guid IdCity { get; set; }
    }
}
