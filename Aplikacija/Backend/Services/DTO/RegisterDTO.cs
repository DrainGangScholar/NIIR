using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.DTO
{
    public class RegisterDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}