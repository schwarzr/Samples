using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using GlobalAzure.CustomSchema.Data;

namespace GlobalAzure.CustomSchema.Data
{
    public class CustomerPayloadItem : IExtendableObject
    {
        public CustomerPayloadItem()
        {
            this.AdditionalProperties = new Dictionary<string, object>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Street { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }

        public string Phone { get; set; }

        public CountryInfo Country { get; set; }


        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties { get; set; }
    }
}