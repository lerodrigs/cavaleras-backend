using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Calaveras.Domain.Entities
{
    public class OrderProduct: GenericEntity
    {
        public int idorder { get; set; }
        public int idproduct { get; set; }
        public int quantity { get; set; }

        [JsonIgnore]
        public virtual Order Order { get; set; }
        [JsonIgnore]
        public virtual Product Product { get; set; }
    }
}
