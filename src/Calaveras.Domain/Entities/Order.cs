using System;
using System.Collections.Generic;
using System.Text;

namespace Calaveras.Domain.Entities
{
    public class Order: GenericEntity
    {
        public Order()
        {
            OrderProduct = new List<OrderProduct>();
        }

        public int idclient { get; set; }
        public int idstore { get; set; }
        public int idstatus { get; set; }
        public int iddeliveryman { get; set; }
        public int? idzipcodeliveryprice { get; set; }

        public DateTime date_order { get; set; }
        public DateTime? date_order_process { get; set; }
        public DateTime? date_order_complete { get; set; }
        public DateTime? date_payment_receive { get; set; }
        public string descritption { get; set; }
        public bool? payment_later { get; set; } 
        public double total_price { get; set; }
        public string signature { get; set; }
        
        public virtual User Client { get; set; }
        public virtual Store Store { get; set; }        
        public virtual OrderStatus OrderStatus { get; set; }
        public virtual DeliveryMan DeliveryMan { get; set; }
        public virtual ZipCodeDeliveryPrice ZipCodeDeliveryPrice { get; set; }
        public virtual ICollection<OrderProduct> OrderProduct { get; set; }
    }
}
