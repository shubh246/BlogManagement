﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class LoginResponseDto
    {
        public User User { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}
