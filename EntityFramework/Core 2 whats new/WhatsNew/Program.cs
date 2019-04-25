using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using WhatsNew.Model;
using Microsoft.EntityFrameworkCore;
using WhatsNew.Model.Translation;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace WhatsNew
{
    internal class Program
    {
        private static void CreateContext(ServiceProvider provider)
        {
            for (int i = 0; i < 100000; i++)
            {
                using (var scope = provider.CreateScope())
                {
                    var db = scope.ServiceProvider.GetService<SampleContext>();
                }
            }
        }

        private static void InitializeDb()
        {
            var cust1 = new Customer { Name = "Customer 1" };
            var cust2 = new Customer { Name = "Customer 2" };
            var invoice1 = new Invoice { InvoiceNumber = "RE0001", Amount = 123, Customer = cust1 };
            var invoice2 = new Invoice { InvoiceNumber = "RE0002", Amount = 123, Customer = cust1 };
            var invoice3 = new Invoice { InvoiceNumber = "RE0003", Amount = 123, Customer = cust1 };

            var builder = new DbContextOptionsBuilder<SampleContext>();
            builder.UseSqlServer("Data Source=.;Initial Catalog=WhatsNew;Integrated Security=True;");

            using (var db = new SampleContext(builder.Options))
            {
                var pending = db.Database.GetPendingMigrations();

                if (pending.Any())
                {
                    db.Database.Migrate();

                    db.AddRange(cust1, cust2);
                    db.AddRange(invoice1, invoice2, invoice3);

                    db.Entry(cust2).Property("IsDeleted").CurrentValue = true;
                    db.Entry(invoice3).Property("IsDeleted").CurrentValue = true;

                    db.SaveChanges();
                }
            }
        }

        private static void Main(string[] args)
        {
            InitializeDb();

            #region Warmup

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<SampleContext>(optionsBuilder =>
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=WhatsNew;Integrated Security=True;"));

            var provider = serviceCollection.BuildServiceProvider();

            using (var scope = provider.CreateScope())
            {
                var db = scope.ServiceProvider.GetService<SampleContext>();
                var count = db.Customers.Count();
            }

            using (var scope = provider.CreateScope())
            {
                var db = scope.ServiceProvider.GetService<SampleContext>();
                var count = db.Customers.Count();
            }

            #endregion Warmup

            ShowCustomers(provider);

            SearchInvoice(provider, "%E000_");
            SearchInvoice(provider, "_e%2");

            var sw = new Stopwatch();
            sw.Start();
            CreateContext(provider);
            sw.Stop();
            Console.WriteLine($"without pool: {sw.Elapsed}");

            var poolCollection = new ServiceCollection();
            poolCollection.AddDbContextPool<SampleContext>(optionsBuilder =>
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=WhatsNew;Integrated Security=True;"));

            var poolProvider = poolCollection.BuildServiceProvider();

            sw.Restart();
            CreateContext(poolProvider);

            sw.Stop();
            Console.WriteLine($"with pool: {sw.Elapsed}");

            sw.Restart();

            // non compiled Query;
            NonPreCompiledQuery(provider);

            sw.Stop();
            Console.WriteLine($"default query: {sw.Elapsed}");
            sw.Restart();

            // compiled Query;
            PreCompiledQuery(provider);

            sw.Stop();
            Console.WriteLine($"compiled query: {sw.Elapsed}");

            Console.ReadLine();
        }

        private static void NonPreCompiledQuery(ServiceProvider provider)
        {
            using (var scope = provider.CreateScope())
            {
                var db = scope.ServiceProvider.GetService<SampleContext>();

                for (int id = 0; id < 500; id++)
                {
                    db.Customers
                    .Include(p => p.Invoices)
                    .SingleOrDefault(p => p.Id == id);
                }
            }
        }

        private static void PreCompiledQuery(ServiceProvider provider)
        {
            var compited = EF.CompileQuery((SampleContext context, int id) =>
                                context.Customers
                    .Include(p => p.Invoices)
                    .SingleOrDefault(p => p.Id == id));

            using (var scope = provider.CreateScope())
            {
                var db = scope.ServiceProvider.GetService<SampleContext>();

                for (int id = 0; id < 500; id++)
                {
                    compited(db, id);
                }
            }
        }

        private static void SearchInvoice(ServiceProvider provider, string pattern)
        {
            using (var scope = provider.CreateScope())
            {
                var db = scope.ServiceProvider.GetService<SampleContext>();
                var invoices = db.Invoices
                    .Where(p => EF.Functions.Like(p.InvoiceNumber, pattern))
                    ;

                Console.WriteLine($"---------------{pattern}---------------");
                foreach (var item in invoices)
                {
                    Console.WriteLine($"Found: {item.InvoiceNumber}");
                }
            }
        }

        private static void ShowCustomers(ServiceProvider provider)
        {
            using (var scope = provider.CreateScope())
            {
                var db = scope.ServiceProvider.GetService<SampleContext>();
                var customers = db.Customers.Include(p => p.Invoices);

                foreach (var item in customers)
                {
                    Console.WriteLine($"Customer {item.Name}");
                    foreach (var iv in item.Invoices)
                    {
                        Console.WriteLine($" - Invoice: {iv.InvoiceNumber}");
                    }
                }
            }
        }
    }
}