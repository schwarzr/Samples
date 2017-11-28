using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorksOrder.Model.Custom
{
    public class SalesOrderDetailItem
    {
        public string CarrierTrackingNumber { get; set; }

        public decimal LineTotal { get; set; }

        public DateTime ModifiedDate { get; set; }

        public short OrderQty { get; set; }

        public EntityInfo Product { get; set; }

        public int SalesOrderDetailId { get; set; }

        public int SalesOrderId { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal UnitPriceDiscount { get; set; }
    }
}