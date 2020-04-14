using System;
using System.Collections.Generic;
using System.Text;

namespace Calaveras.Domain.Entities
{
    public class ZipCodeDeliveryPrice: GenericEntity 
    {
        public int idzipcodemin { get; set; }
        public int idzipcodemax { get; set; }
        public string description { get; set; }
        public double price { get; set; }

        public virtual ZipCode ZipCodeMin { get; set; }
        public virtual ZipCode ZipCodeMax { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
