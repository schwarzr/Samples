using System.Linq;
using System.Web.OData;
using System.Web.Http.Cors;
using AdventureWorksOrder.Model.Custom;

namespace AdventureWorksOrder.OData.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class OrdersController : ODataController
    {
        private readonly AdventureWorksContext _db;

        public OrdersController()
        {
            _db = new AdventureWorksContext();
        }

        [EnableQuery]
        public IQueryable<SalesOrderListItem> Get()
        {
            var data = _db.SalesOrderHeader
                            .Select(p => new SalesOrderListItem
                            {
                                SalesOrderId = p.SalesOrderID,
                                Customer = string.Concat("(", p.Customer.AccountNumber, ") ", p.Customer.Person.FirstName, " ", p.Customer.Person.LastName),
                                OrderDate = p.OrderDate,
                                OrderNumber = p.SalesOrderNumber,
                                SalesTerritoryId = p.TerritoryID
                            });

            return data;
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
        }
    }
}