using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using LargeData.Database;
using LargeData.Model;
using LargeDate.Contract;
using LargeData.Model.Custom;

public class InternetSalesDataAccess
{
    public static async Task<IQueryable<InternetSaleInfo>> GetInternetSaleInfosQueryAsync(AdventureWorksContext context, DateTime? from, DateTime? until)
    {
        var query = await GetInternetSalesQueryAsync(context, from, until);
        return query.Select(p => new InternetSaleInfo
        {
            Order = p.SalesOrderNumber,
            Pos = p.SalesOrderLineNumber,
            Customer = p.Customer.FirstName + " " + p.Customer.LastName,
            CustomerLocation = p.Customer.Geography.City + " (" + p.Customer.Geography.EnglishCountryRegionName + ")",
            Quantity = p.OrderQuantity,
            Price = p.UnitPrice,
            Currency = p.Currency.CurrencyName,
            Total = p.SalesAmount,
            Date = p.OrderDate,
            Promotion = p.Promotion.EnglishPromotionName
        });
    }

    public static Task<IQueryable<InternetSale>> GetInternetSalesQueryAsync(AdventureWorksContext context, DateTime? from, DateTime? until)
    {
        IQueryable<InternetSale> query = context.InternetSales
                                            .AsNoTracking()
                                            .Include(p => p.Customer.Geography)
                                            .Include(p => p.Currency)
                                            .Include(p => p.Promotion);
        if (from.HasValue)
        {
            query = query.Where(p => p.OrderDate.Value >= from.Value);
        }
        if (until.HasValue)
        {
            query = query.Where(p => p.OrderDate.Value < until.Value);
        }

        return Task.FromResult(query);
    }
}