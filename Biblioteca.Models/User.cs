﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Models
{
    public class User
    {
        public int id_User { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public char Role { get; set; }
    }
}
