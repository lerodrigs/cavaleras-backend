using System;
using System.Collections.Generic;
using System.Text;

namespace Calaveras.Domain.Entities
{
    public class OrderProduct: GenericEntity
    {
        public int idorder { get; set; }
        public int idproduct { get; set; }
        public int quantity { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
