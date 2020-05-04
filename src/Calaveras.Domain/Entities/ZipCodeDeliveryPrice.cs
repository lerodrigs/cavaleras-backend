using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Calaveras.Domain.Entities
{
    public class ZipCodeDeliveryPrice: GenericEntity 
    {
        public ZipCodeDeliveryPrice()
        {
            Orders = new List<Order>();
        }
        
        public int idzipcodemin { get; set; }
        public int idzipcodemax { get; set; }
        public string description { get; set; }
        public double price { get; set; }

        [JsonIgnore]
        public virtual ZipCode ZipCodeMin { get; set; }
        [JsonIgnore]
        public virtual ZipCode ZipCodeMax { get; set; }
        [JsonIgnore]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
