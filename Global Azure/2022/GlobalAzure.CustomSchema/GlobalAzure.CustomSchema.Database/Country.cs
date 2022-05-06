using System.ComponentModel.DataAnnotations;

namespace GlobalAzure.CustomSchema.Database
{
    public class Country
    {
        public Guid Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(3)]
        public string Iso3 { get; set; }
    }
}