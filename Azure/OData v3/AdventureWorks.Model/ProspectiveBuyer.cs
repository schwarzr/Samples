namespace AdventureWorks.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProspectiveBuyer")]
    public partial class ProspectiveBuyer
    {
        [Key]
        public int ProspectiveBuyerKey { get; set; }

        [StringLength(15)]
        public string ProspectAlternateKey { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string MiddleName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        [StringLength(1)]
        public string MaritalStatus { get; set; }

        [StringLength(1)]
        public string Gender { get; set; }

        [StringLength(50)]
        public string EmailAddress { get; set; }

        [Column(TypeName = "money")]
        public decimal? YearlyIncome { get; set; }

        public byte? TotalChildren { get; set; }

        public byte? NumberChildrenAtHome { get; set; }

        [StringLength(40)]
        public string Education { get; set; }

        [StringLength(100)]
        public string Occupation { get; set; }

        [StringLength(1)]
        public string HouseOwnerFlag { get; set; }

        public byte? NumberCarsOwned { get; set; }

        [StringLength(120)]
        public string AddressLine1 { get; set; }

        [StringLength(120)]
        public string AddressLine2 { get; set; }

        [StringLength(30)]
        public string City { get; set; }

        [StringLength(3)]
        public string StateProvinceCode { get; set; }

        [StringLength(15)]
        public string PostalCode { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        [StringLength(8)]
        public string Salutation { get; set; }

        public int? Unknown { get; set; }
    }
}
