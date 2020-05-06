using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Calaveras.Domain.Entities
{
    public class User: IdentityUser
    {
        public User()
        {
            Orders = new List<Order>();
            Addresses = new List<Address>();
        }

        public string name { get; set; }
        public override string PhoneNumber { get; set; }
        public override string Email { get; set; }
        public string cpf { get; set; }
        public DateTime birthday { get; set; }
        public string signature { get; set; }
        [NotMapped]
        public string password { get; set; }

        //[JsonIgnore]
        //public override string NormalizedUserName { get; set; }
        //[JsonIgnore]
        //public override string NormalizedEmail { get; set; }
        //[JsonIgnore]
        //public override string PasswordHash { get; set; }
        //[JsonIgnore]
        //public override bool PhoneNumberConfirmed { get; set; }
        //[JsonIgnore]
        //public override string SecurityStamp { get; set; }
        //[JsonIgnore]
        //public override bool TwoFactorEnabled { get; set; }
        //[JsonIgnore]
        //public override string UserName { get; set; }
        //[JsonIgnore]
        //public override DateTimeOffset? LockoutEnd { get; set; }
        //[JsonIgnore]
        //public override bool LockoutEnabled { get; set; }
        //[JsonIgnore]
        //public override bool EmailConfirmed { get; set; }
        //[JsonIgnore]
        //public override string ConcurrencyStamp { get; set; }
        //[JsonIgnore]
        //public override int AccessFailedCount { get; set; }

        [JsonIgnore]
        public virtual ICollection<Order> Orders { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
