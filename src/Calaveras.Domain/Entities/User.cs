using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Calaveras.Domain.Entities
{
    public class User: IdentityUser
    {
        public User()
        {
            Orders = new List<Order>();
        }

        public string name { get; set; }
        public string cpf { get; set; }
        public string zipcode { get; set; }
        public string address { get; set; }
        public string number { get; set; }
        public string apto { get; set; } 
        public string signature { get; set; }

        [JsonIgnore]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
