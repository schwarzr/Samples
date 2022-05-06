using GlobalAzure.CustomSchema.Data;
using GlobalAzure.CustomSchema.Database;
using GlobalAzure.CustomSchema.Database.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GlobalAzure.CustomSchema.Controllers
{
    [Route("api/[controller]")]
    public class CrmController
    {
        private readonly CrmContext _db;

        public CrmController(CrmContext db)
        {
            _db = db;
        }

        [HttpGet()]
        public async Task<IEnumerable<CustomerListData>> GetCustomerListDataAsync()
        {
            var data = await _db.Customers.Select(p => new CustomerListData
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                City = p.City,
                Country = p.Country.Name + " (" + p.Country.Iso3 + ")",
                Created = p.Created,
            }).ToListAsync();

            return data;
        }

        [HttpPost()]
        public async Task<CustomerDetailItem> CreateCustomerAsync([FromBody] CustomerPayloadItem payload)
        {
            var dbItem = new Customer
            {
                Id = Guid.NewGuid(),
                City = payload.City,
                CountryId = payload.Country.Id,
                FirstName = payload.FirstName,
                LastName = payload.LastName,
                Phone = payload.Phone,
                Street = payload.Street,
                ZipCode = payload.ZipCode,
                Created = DateTime.UtcNow,
            };

            _db.Add(dbItem);

            var entry = _db.Entry(dbItem);
            entry.UpdateAdditionalProperties(payload);

            await _db.SaveChangesAsync();

            return await GetCustomerDetailItemAsync(dbItem.Id);
        }

        [HttpPut("{id:guid}")]
        public async Task<CustomerDetailItem> UpdateCustomerAsync(Guid id, [FromBody] CustomerPayloadItem payload)
        {
            var dbItem = await _db.Customers.FirstAsync(p => p.Id == id);

            dbItem.City = payload.City;
            dbItem.CountryId = payload.Country.Id;
            dbItem.FirstName = payload.FirstName;
            dbItem.LastName = payload.LastName;
            dbItem.Phone = payload.Phone;
            dbItem.Street = payload.Street;
            dbItem.ZipCode = payload.ZipCode;

            var entry = _db.Entry(dbItem);
            entry.UpdateAdditionalProperties(payload);

            await _db.SaveChangesAsync();

            return await GetCustomerDetailItemAsync(dbItem.Id);
        }


        [HttpGet("{id:guid}")]
        public async Task<CustomerDetailItem> GetCustomerDetailItemAsync(Guid id)
        {
            var data = await _db.Customers
                .Where(p => p.Id == id)
                .Select(p => new CustomerDetailItem
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    City = p.City,
                    Phone = p.Phone,
                    Street = p.Street,
                    ZipCode = p.ZipCode,
                    Country = new CountryInfo
                    {
                        Id = p.Country.Id,
                        DisplayName = p.Country.Name + " (" + p.Country.Iso3 + ")",
                    },
                    Created = p.Created
                }).FirstOrDefaultAsync();

            return data;
        }
    }
}
