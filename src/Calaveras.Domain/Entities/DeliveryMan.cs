using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Calaveras.Domain.Entities
{
    public class DeliveryMan: GenericEntity
    {
        public DeliveryMan()
        {
            Orders = new List<Order>(); 
        }

        public string name { get; set; }
        public bool avaliable { get; set; }

        [JsonIgnore]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
