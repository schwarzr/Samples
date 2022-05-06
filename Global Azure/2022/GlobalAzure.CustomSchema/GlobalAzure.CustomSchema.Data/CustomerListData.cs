namespace GlobalAzure.CustomSchema.Data
{
    public class CustomerListData : IExtendableObject
    {

        public CustomerListData()
        {
            this.AdditionalProperties = new Dictionary<string, object>();
        }
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Created { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        [System.Text.Json.Serialization.JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties { get; set; }
    }
}