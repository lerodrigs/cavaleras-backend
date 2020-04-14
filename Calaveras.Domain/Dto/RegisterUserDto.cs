using System;
using System.Collections.Generic;
using System.Text;

namespace Calaveras.Domain.Dto
{
    public class RegisterUserDto
    {
        public string email { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string cpf { get; set; }
        public string cellphone { get; set; }
        public string zipcode { get; set; }
        public string address { get; set; }
        public string number { get; set; }
    }
}
