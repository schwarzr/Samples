using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructionDiary.Api.Contract;
using ConstructionDiary.AspNetCore.Client;
using ConstructionDiary.Model;

namespace ConstructionDiary.Api.Client
{
    public class CountryControllerClient : RestClient<ICountryController>, ICountryController
    {
        public CountryControllerClient(RestOptions<ICountryController> options)
            : base(options)
        {
        }

        public Task DeleteCountryAsync(Guid id)
        {
            return this.CallAsync(p => p.DeleteCountryAsync(id));
        }

        public Task<CountryListItem> GetCountryAsync(Guid id)
        {
            return this.CallAsync(p => p.GetCountryAsync(id));
        }

        public Task<IEnumerable<CountryInfo>> GetCountryInfosAsync()
        {
            return this.CallAsync(p => p.GetCountryInfosAsync());
        }

        public Task<IEnumerable<CountryListItem>> GetCountryListItemsAsync()
        {
            return this.CallAsync(p => p.GetCountryListItemsAsync());
        }

        public Task InsertCountryAsync(CountryListItem item)
        {
            return this.CallAsync(p => p.InsertCountryAsync(item));
        }

        public Task UpdateCountryAsync(CountryListItem item)
        {
            return this.CallAsync(p => p.UpdateCountryAsync(item));
        }
    }
}