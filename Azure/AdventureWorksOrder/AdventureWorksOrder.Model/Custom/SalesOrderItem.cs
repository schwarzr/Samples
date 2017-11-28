using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorksOrder.Model.Custom
{
    public class SalesOrderItem
    {
        public string AccountNumber { get; set; }

        public EntityInfo BillingAddress { get; set; }

        public EntityInfo CreditCard { get; set; }

        public EntityInfo CurrencyRate { get; set; }

        public EntityInfo Customer { get; set; }

        public DateTime SalesOrderDate { get; set; }

        public int SalesOrderId { get; set; }

        public string SalesOrderNumber { get; set; }

        public EntityInfo SalesPerson { get; set; }

        public EntityInfo SalesTerritory { get; set; }

        public EntityInfo ShipMethod { get; set; }

        public EntityInfo ShippingAddress { get; set; }
    }
}