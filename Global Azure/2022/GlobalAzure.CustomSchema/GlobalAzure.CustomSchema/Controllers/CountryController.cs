using GlobalAzure.CustomSchema.Data;
using GlobalAzure.CustomSchema.Database;
using GlobalAzure.CustomSchema.Database.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GlobalAzure.CustomSchema.Controllers
{
    [Route("api/[controller]")]
    public class CountryController
    {
        private readonly CrmContext _db;

        public CountryController(CrmContext db)
        {
            _db = db;
        }

        [HttpGet()]
        public async Task<IEnumerable<CountryInfo>> GetCountryInfosAsync()
        {
            var data = await _db.Countries.Select(p => new CountryInfo
            {
                Id = p.Id,
                DisplayName = p.Name + " (" + p.Iso3 + ")",
            }).ToListAsync();

            return data;
        }

        [HttpPost()]
        public async Task<CountryInfo> CreateCountryAsync([FromBody] CountryPayload payload)
        {
            var dbItem = new Country
            {
                Id = Guid.NewGuid(),
                Name = payload.Name,
                Iso3 = payload.Iso3,
            };

            _db.Add(dbItem);

            await _db.SaveChangesAsync();

            return await GetCountryInfoByIdAsync(dbItem.Id);
        }


        [HttpGet("{id:guid}")]
        public async Task<CountryInfo> GetCountryInfoByIdAsync(Guid id)
        {
            var data = await _db.Countries
                .Where(p => p.Id == id)
                .Select(p => new CountryInfo
                {
                    Id = p.Id,
                    DisplayName = p.Name + " (" + p.Iso3 + ")",

                }).FirstOrDefaultAsync();

            return data;
        }
    }
}
