using System.ComponentModel.DataAnnotations;

namespace GlobalAzure.CustomSchema.Database
{
    public class Customer
    {
        public Guid Id { get; set; }

        [StringLength(500)]
        public string? FirstName { get; set; }

        [StringLength(500)]
        public string LastName { get; set; }

        [StringLength(500)]
        public string? Street { get; set; }

        [StringLength(10)]
        public string? ZipCode { get; set; }

        [StringLength(300)]
        public string? City { get; set; }

        [StringLength(30)]
        public string? Phone { get; set; }

        public Guid CountryId { get; set; }

        public Country Country { get; set; }

        public DateTime Created { get; set; }
    }
}