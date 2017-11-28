using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorksOrder.Model.Custom
{
    public class SalesOrderListItem
    {
        public string Customer { get; set; }

        public DateTime OrderDate { get; set; }

        public string OrderNumber { get; set; }

        public int SalesOrderId { get; set; }

        public int? SalesTerritoryId { get; set; }
    }
}