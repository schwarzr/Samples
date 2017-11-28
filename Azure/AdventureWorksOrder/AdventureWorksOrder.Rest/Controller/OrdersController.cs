using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventureWorksOrder.Database;
using AdventureWorksOrder.Model.Custom;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksOrder.Rest.Controller
{
    [Route("api/[controller]")]
    public class OrdersController
    {
        private readonly AdventureWorksContext _db;

        public OrdersController(AdventureWorksContext db)
        {
            _db = db;
        }

        [HttpGet("creditcards")]
        public async Task<IEnumerable<EntityInfo>> GetCreditCardsAsync(int customerId)
        {
            var data = await _db.Customer
                                .Where(p => p.CustomerId == customerId)
                                .SelectMany(p => p.Person.PersonCreditCard)
                            .Select(p => new EntityInfo
                            {
                                Id = p.CreditCard.CreditCardId,
                                Name = string.Concat(p.CreditCard.CardNumber, "(", p.CreditCard.ExpMonth, "/", p.CreditCard.ExpYear, ")")
                            })
                            .ToListAsync();

            return data;
        }

        [HttpGet("currency")]
        public async Task<IEnumerable<EntityInfo>> GetCurrencyRatesAsync()
        {
            var data = await _db.CurrencyRate
                            .Select(p => new EntityInfo
                            {
                                Id = p.CurrencyRateId,
                                Name = string.Concat(p.FromCurrencyCode, " - ", p.ToCurrencyCode, " = ", p.AverageRate)
                            })
                            .ToListAsync();

            return data;
        }

        [HttpGet("customers")]
        public async Task<IEnumerable<EntityInfo>> GetCustomersAsync()
        {
            var data = await _db.Customer
                            .Select(p => new EntityInfo
                            {
                                Id = p.CustomerId,
                                Name = string.Concat(p.Person.FirstName, " ", p.Person.LastName)
                            })
                            .ToListAsync();

            return data;
        }

        [HttpGet]
        public async Task<IEnumerable<SalesOrderListItem>> GetSalesAsync(int salesTerritoryId)
        {
            var data = await _db.SalesOrderHeader
                            .Where(p => p.TerritoryId == salesTerritoryId)
                            .Select(p => new SalesOrderListItem
                            {
                                SalesOrderId = p.SalesOrderId,
                                Customer = string.Concat("(", p.Customer.AccountNumber, ") ", p.Customer.Person.FirstName, " ", p.Customer.Person.LastName),
                                OrderDate = p.OrderDate,
                                OrderNumber = p.SalesOrderNumber,
                                SalesTerritoryId = p.TerritoryId
                            })
                            .ToListAsync();

            return data;
        }

        [HttpGet("{id}")]
        public async Task<SalesOrderItem> GetSalesOrder(int id)
        {
            var data = await _db.SalesOrderHeader
                            .Where(p => p.SalesOrderId == id)
                            .Select(p => new SalesOrderItem
                            {
                                SalesOrderId = p.SalesOrderId,
                                AccountNumber = p.AccountNumber,
                                BillingAddress = new EntityInfo { Id = p.BillToAddress.AddressId, Name = string.Concat(p.BillToAddress.AddressLine1, ", ", p.BillToAddress.PostalCode, "", p.BillToAddress.City) },
                                CreditCard = p.CreditCardId != null ? new EntityInfo { Id = p.CreditCard.CreditCardId, Name = string.Concat(p.CreditCard.CardNumber, "(", p.CreditCard.ExpMonth, "/", p.CreditCard.ExpYear, ")") } : null,
                                CurrencyRate = p.CurrencyRateId != null ? new EntityInfo { Id = p.CurrencyRate.CurrencyRateId, Name = string.Concat(p.CurrencyRate.FromCurrencyCode, " - ", p.CurrencyRate.ToCurrencyCode, " = ", p.CurrencyRate.AverageRate) } : null,
                                Customer = new EntityInfo { Id = p.Customer.CustomerId, Name = string.Concat(p.Customer.Person.FirstName, " ", p.Customer.Person.LastName) },
                                SalesOrderDate = p.OrderDate,
                                SalesOrderNumber = p.SalesOrderNumber,
                                SalesPerson = p.SalesPersonId != null ? new EntityInfo { Id = p.SalesPerson.BusinessEntityId, Name = p.SalesPerson.BusinessEntity.BusinessEntity.FirstName } : null,
                                SalesTerritory = p.TerritoryId != null ? new EntityInfo { Id = p.Territory.TerritoryId, Name = p.Territory.Name } : null,
                                ShipMethod = new EntityInfo { Id = p.ShipMethod.ShipMethodId, Name = p.ShipMethod.Name },
                                ShippingAddress = new EntityInfo { Id = p.ShipToAddress.AddressId, Name = string.Concat(p.ShipToAddress.AddressLine1, ", ", p.ShipToAddress.PostalCode, "", p.ShipToAddress.City) },
                            }).FirstOrDefaultAsync();

            return data;
        }

        [HttpGet("{id}/items")]
        public async Task<IEnumerable<SalesOrderDetailItem>> GetSalesOrderDetailItems(int id)
        {
            var data = await _db.SalesOrderDetail.Where(p => p.SalesOrderId == id)
                            .Select(p => new SalesOrderDetailItem
                            {
                                SalesOrderDetailId = p.SalesOrderDetailId,
                                CarrierTrackingNumber = p.CarrierTrackingNumber,
                                LineTotal = p.LineTotal,
                                ModifiedDate = p.ModifiedDate,
                                OrderQty = p.OrderQty,
                                Product = new EntityInfo { Id = p.SpecialOfferProduct.ProductId, Name = p.SpecialOfferProduct.Product.Name },
                                SalesOrderId = p.SalesOrderId,
                                UnitPrice = p.UnitPrice,
                                UnitPriceDiscount = p.UnitPriceDiscount
                            }).ToListAsync();

            return data;
        }

        [HttpGet("salespeople")]
        public async Task<IEnumerable<EntityInfo>> GetSalesPeopleAsync()
        {
            var data = await _db.SalesPerson
                            .Select(p => new EntityInfo
                            {
                                Id = p.BusinessEntityId,
                                Name = string.Concat(p.BusinessEntity.BusinessEntity.FirstName, " ", p.BusinessEntity.BusinessEntity.LastName)
                            })
                            .ToListAsync();

            return data;
        }

        [HttpGet("territories")]
        public async Task<IEnumerable<EntityInfo>> GetSalesTerritoriesAsync()
        {
            var data = await _db.SalesTerritory
                            .Select(p => new EntityInfo
                            {
                                Id = p.TerritoryId,
                                Name = p.Name
                            })
                            .ToListAsync();

            return data;
        }

        [HttpGet("shipmethods")]
        public async Task<IEnumerable<EntityInfo>> GetShipMethodsAsync()
        {
            var data = await _db.ShipMethod
                            .Select(p => new EntityInfo
                            {
                                Id = p.ShipMethodId,
                                Name = p.Name
                            })
                            .ToListAsync();

            return data;
        }

        [HttpGet("addresses/shipping")]
        public async Task<IEnumerable<EntityInfo>> GetShippingAddressesAsync(int customerId)
        {
            var data = await _db.Customer.
                                Where(p => p.CustomerId == customerId)
                                .SelectMany(p => p.Store.BusinessEntity.BusinessEntityAddress)
                                .Select(p => new EntityInfo
                                {
                                    Id = p.Address.AddressId,
                                    Name = string.Concat(p.Address.AddressLine1, ", ", p.Address.PostalCode, " ", p.Address.City)
                                })
                            .ToListAsync();

            return data;
        }
    }
}