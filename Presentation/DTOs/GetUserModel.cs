﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.DTOs
{
    public class GetUserModel
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Country { get; set; }

        public string City { get; set; }
    }
}