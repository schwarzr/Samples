// <auto-generated />
[assembly: Codeworx.Rest.RestProxy(typeof(global::ConstructionDiary.Contract.ICountryService), typeof(ConstructionDiary.Client.Generated.CountryServiceClient))]
namespace ConstructionDiary.Client.Generated
{
    public class CountryServiceClient : Codeworx.Rest.Client.RestClient<global::ConstructionDiary.Contract.ICountryService>, global::ConstructionDiary.Contract.ICountryService
    {
        public CountryServiceClient(Codeworx.Rest.Client.RestOptions<global::ConstructionDiary.Contract.ICountryService> options): base(options)
        {
        }

        public global::System.Threading.Tasks.Task DeleteCountryAsync(global::System.Guid id)
        {
            return CallAsync(c => c.DeleteCountryAsync(id));
        }

        public global::System.Threading.Tasks.Task<global::ConstructionDiary.Model.CountryListItem> GetCountryAsync(global::System.Guid id)
        {
            return CallAsync(c => c.GetCountryAsync(id));
        }

        public global::System.Threading.Tasks.Task<global::System.Collections.Generic.IEnumerable<global::ConstructionDiary.Model.CountryInfo>> GetCountryInfosAsync()
        {
            return CallAsync(c => c.GetCountryInfosAsync());
        }

        public global::System.Threading.Tasks.Task<global::System.Collections.Generic.IEnumerable<global::ConstructionDiary.Model.CountryListItem>> GetCountryListItemsAsync()
        {
            return CallAsync(c => c.GetCountryListItemsAsync());
        }

        public global::System.Threading.Tasks.Task InsertCountryAsync(global::ConstructionDiary.Model.CountryListItem item)
        {
            return CallAsync(c => c.InsertCountryAsync(item));
        }

        public global::System.Threading.Tasks.Task UpdateCountryAsync(global::ConstructionDiary.Model.CountryListItem item)
        {
            return CallAsync(c => c.UpdateCountryAsync(item));
        }
    }
}