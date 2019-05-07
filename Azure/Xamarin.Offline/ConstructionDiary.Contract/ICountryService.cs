using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ConstructionDiary.Model;

namespace ConstructionDiary.Contract
{
    public interface ICountryService
    {
        Task DeleteCountryAsync(Guid id);

        Task<CountryListItem> GetCountryAsync(Guid id);

        Task<IEnumerable<CountryInfo>> GetCountryInfosAsync();

        Task<IEnumerable<CountryListItem>> GetCountryListItemsAsync();

        Task InsertCountryAsync(CountryListItem item);

        Task UpdateCountryAsync(CountryListItem item);
    }
}