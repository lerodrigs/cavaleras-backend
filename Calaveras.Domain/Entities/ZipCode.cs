using System;
using System.Collections.Generic;
using System.Text;

namespace Calaveras.Domain.Entities
{
    public class ZipCode: GenericEntity
    {
        public ZipCode()
        {
            ZipCodeDeliveryPrices = new List<ZipCodeDeliveryPrice>();
        }

        public string description { get; set; }
        public virtual ICollection<ZipCodeDeliveryPrice> ZipCodeDeliveryPrices { get; set; }
    }
}
