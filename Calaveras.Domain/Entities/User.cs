using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calaveras.Domain.Entities
{
    public class User: IdentityUser<int>
    {
        public User()
        {
            Orders = new List<Order>();
        }

        public string name { get; set; }
        public string cpf { get; set; }
        public string cellphone { get; set; }
        public string zipcode { get; set; }
        public string address { get; set; }
        public string number { get; set; }
        public string signature { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
