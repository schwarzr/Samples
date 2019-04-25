using System.ComponentModel.DataAnnotations;

namespace WhatsNew.Model
{
    public class Address
    {
        [StringLength(200)]
        public string City { get; set; }

        [StringLength(200)]
        public string Street { get; set; }

        [StringLength(200)]
        public string ZipCode { get; set; }
    }
}