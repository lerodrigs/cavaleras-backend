﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Calaveras.Domain.Entities
{
    public class Product: GenericEntity
    {
        public Product()
        {
            OrderProduct = new List<OrderProduct>();
        }

        public string description { get; set; }
        public double price { get; set; }
        public bool avaliable { get; set; }

        [JsonIgnore]
        public virtual ICollection<OrderProduct> OrderProduct { get; set; }
    }
}
