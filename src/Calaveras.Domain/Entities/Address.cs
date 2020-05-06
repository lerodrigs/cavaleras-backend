using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Calaveras.Domain.Entities
{
    public class Address: GenericEntity
    {
        public string idclient { get; set; }

        public string street { get; set; }
        public string number { get; set; }
        public string apto { get; set; }
        public string city { get; set; }
        public string neighborhood { get; set; }
        public string state { get; set; }
        public string zipcode { get; set; }
        public bool selected { get; set; } = false;

        [JsonIgnore]
        public virtual User User { get; set; }
    }
}
