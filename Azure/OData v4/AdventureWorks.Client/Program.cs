using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Client
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var container = new Default.Container(new Uri("http://localhost:52126/odata"));

            var query = container.InternetSales.Where(p => p.DimSalesReasons.Any(x => x.SalesReasonName == "Quality"));

            var items = query.ToList();

            Console.WriteLine($"found {items.Count} items");

            foreach (var item in items)
            {
                Console.WriteLine($" - {item.SalesOrderNumber} - {item.SalesOrderLineNumber}");
            }

            Console.WriteLine("Done");
        }
    }
}