namespace AdventureWorks.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DimCustomer")]
    public partial class DimCustomer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DimCustomer()
        {
            FactInternetSales = new HashSet<FactInternetSale>();
            FactSurveyResponses = new HashSet<FactSurveyResponse>();
        }

        [Key]
        public int CustomerKey { get; set; }

        public int? GeographyKey { get; set; }

        [Required]
        [StringLength(15)]
        public string CustomerAlternateKey { get; set; }

        [StringLength(8)]
        public string Title { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string MiddleName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        public bool? NameStyle { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BirthDate { get; set; }

        [StringLength(1)]
        public string MaritalStatus { get; set; }

        [StringLength(10)]
        public string Suffix { get; set; }

        [StringLength(1)]
        public string Gender { get; set; }

        [StringLength(50)]
        public string EmailAddress { get; set; }

        [Column(TypeName = "money")]
        public decimal? YearlyIncome { get; set; }

        public byte? TotalChildren { get; set; }

        public byte? NumberChildrenAtHome { get; set; }

        [StringLength(40)]
        public string EnglishEducation { get; set; }

        [StringLength(40)]
        public string SpanishEducation { get; set; }

        [StringLength(40)]
        public string FrenchEducation { get; set; }

        [StringLength(100)]
        public string EnglishOccupation { get; set; }

        [StringLength(100)]
        public string SpanishOccupation { get; set; }

        [StringLength(100)]
        public string FrenchOccupation { get; set; }

        [StringLength(1)]
        public string HouseOwnerFlag { get; set; }

        public byte? NumberCarsOwned { get; set; }

        [StringLength(120)]
        public string AddressLine1 { get; set; }

        [StringLength(120)]
        public string AddressLine2 { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateFirstPurchase { get; set; }

        [StringLength(15)]
        public string CommuteDistance { get; set; }

        public virtual DimGeography DimGeography { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FactInternetSale> FactInternetSales { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FactSurveyResponse> FactSurveyResponses { get; set; }
    }
}
