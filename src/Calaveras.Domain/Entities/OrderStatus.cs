using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Calaveras.Domain.Entities
{
    public class OrderStatus: GenericEntity
    {
        public OrderStatus()
        {
            Orders = new List<Order>();
        }

        public string description { get; set; }
        [JsonIgnore]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
