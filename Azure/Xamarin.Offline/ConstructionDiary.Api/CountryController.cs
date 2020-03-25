using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ConstructionDiary.Api.Contract;
using ConstructionDiary.Contract;
using ConstructionDiary.Model;

namespace ConstructionDiary.Api
{
    public class CountryController : ICountryController
    {
        private readonly ICountryService _service;

        public CountryController(ICountryService service)
        {
            this._service = service;
        }

        public Task DeleteCountryAsync(Guid id)
        {
            return _service.DeleteCountryAsync(id);
        }

        public Task<CountryListItem> GetCountryAsync(Guid id)
        {
            return _service.GetCountryAsync(id);
        }

        public Task<IEnumerable<CountryInfo>> GetCountryInfosAsync()
        {
            return _service.GetCountryInfosAsync();
        }

        public Task<IEnumerable<CountryListItem>> GetCountryListItemsAsync()
        {
            return _service.GetCountryListItemsAsync();
        }

        public Task InsertCountryAsync(CountryListItem item)
        {
            return _service.InsertCountryAsync(item);
        }

        public Task UpdateCountryAsync(CountryListItem item)
        {
            return _service.UpdateCountryAsync(item);
        }
    }
}