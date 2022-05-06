using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using GlobalAzure.CustomSchema.Data;

namespace GlobalAzure.CustomSchema.Data
{
    public class CustomerDetailItem : CustomerPayloadItem
    {
        public CustomerDetailItem()
        {
        }

        public Guid Id { get; set; }

        public DateTime Created { get; set; }
    }
}