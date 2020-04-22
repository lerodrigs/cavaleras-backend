using System;
using System.Collections.Generic;
using System.Text;

namespace Calaveras.Domain.Entities
{
    public class ZipCode: GenericEntity
    {
        public ZipCode()
        {
            ZipCodeDeliveryPricesMin = new List<ZipCodeDeliveryPrice>();
            ZipCodeDeliveryPricesMax = new List<ZipCodeDeliveryPrice>();
        }

        public string description { get; set; }
        public virtual ICollection<ZipCodeDeliveryPrice> ZipCodeDeliveryPricesMin { get; set; }
        public virtual ICollection<ZipCodeDeliveryPrice> ZipCodeDeliveryPricesMax { get; set; }
    }
}
