using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Codeworx.Rest;
using ConstructionDiary.Model;

namespace ConstructionDiary.Contract
{
    [RestRoute("api/country")]
    public interface ICountryService
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
        Task InsertCountryAsync([BodyMember]CountryListItem item);

        [RestPut("")]
        Task UpdateCountryAsync([BodyMember] CountryListItem item);
    }
}