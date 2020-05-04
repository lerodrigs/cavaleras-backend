using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Calaveras.Domain.Entities
{
    public class Store: GenericEntity
    {
        public Store()
        {
            Orders = new List<Order>();
        }

        public string address { get; set; }
        public string number { get; set; }
        public string description { get; set; }
        public string info { get; set; }
        public string time_delivery { get; set; }
        public bool avaliable { get; set; }

        [JsonIgnore]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
