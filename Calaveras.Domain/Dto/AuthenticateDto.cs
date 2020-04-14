using System;
using System.Collections.Generic;
using System.Text;

namespace Calaveras.Domain.Dto
{
    public class AuthenticateDto
    {
        public string email { get; set; }
        public string password { get; set; }
    }
}
