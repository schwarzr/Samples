using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConstructionDiary.Contract;
using ConstructionDiary.Database;
using ConstructionDiary.Model;
using Microsoft.EntityFrameworkCore;

namespace ConstructionDiary.Service
{
    public class CountryService : ICountryService
    {
        private readonly DiaryContext _context;

        public CountryService(DiaryContext context)
        {
            _context = context;
        }

        public async Task DeleteCountryAsync(Guid id)
        {
            var entity = await _context.Countries.FirstAsync(p => p.Id == id);
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<CountryListItem> GetCountryAsync(Guid id)
        {
            var query = GetCountryListItemsQuery();
            return await query.FirstAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<CountryInfo>> GetCountryInfosAsync()
        {
            var query = GetCountryListItemsQuery();
            return await query.Select(p => new CountryInfo { Id = p.Id, DisplayString = p.Name + " (" + p.IsoTwo + ")" }).ToListAsync();
        }

        public async Task<IEnumerable<CountryListItem>> GetCountryListItemsAsync()
        {
            var query = GetCountryListItemsQuery();
            return await query.ToListAsync();
        }

        public async Task InsertCountryAsync(CountryListItem item)
        {
            _context.Countries.Add(new Database.Entities.Country { Id = Guid.NewGuid(), Name = item.Name, TwoLetterIso = item.IsoTwo });
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCountryAsync(CountryListItem item)
        {
            var country = await _context.Countries.FirstAsync(p => p.Id == item.Id);
            country.Name = item.Name;
            country.TwoLetterIso = item.IsoTwo;

            await _context.SaveChangesAsync();
        }

        private IQueryable<CountryListItem> GetCountryListItemsQuery()
        {
            return _context.Countries.Select(p => new CountryListItem { Id = p.Id, IsoTwo = p.TwoLetterIso, Name = p.Name });
        }
    }
}