using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructionDiary.Model;

namespace ConstructionDiary.Api.Contract
{
    [RestRoute("api/country")]
    public interface ICountryController
    {
        [RestDelete("{id}")]
        Task DeleteCountryAsync(Guid id);

        [RestGet("{id}")]
        Task<CountryListItem> GetCountryAsync(Guid id);

        [RestGet("infos")]
        Task<IEnumerable<CountryInfo>> GetCountryInfosAsync();

        [RestGet("list")]
        Task<IEnumerable<CountryListItem>> GetCountryListItemsAsync();

        [RestPost("")]
        Task InsertCountryAsync(CountryListItem item);

        [RestPut("")]
        Task UpdateCountryAsync(CountryListItem item);
    }
}