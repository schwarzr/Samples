namespace LargeData.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;

    [Table("DimCustomer")]
    [DataContract(IsReference = true)]
    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            InternetSales = new HashSet<InternetSale>();
        }

        [StringLength(120)]
        [DataMember(Order = 1)]
        public string AddressLine1 { get; set; }

        [StringLength(120)]
        [DataMember(Order = 2)]
        public string AddressLine2 { get; set; }

        [Column(TypeName = "date")]
        [DataMember(Order = 3)]
        public DateTime? BirthDate { get; set; }

        [StringLength(15)]
        [DataMember(Order = 4)]
        public string CommuteDistance { get; set; }

        [Required]
        [StringLength(15)]
        [DataMember(Order = 5)]
        public string CustomerAlternateKey { get; set; }

        [Key]
        [DataMember(Order = 6)]
        public int CustomerKey { get; set; }

        [Column(TypeName = "date")]
        [DataMember(Order = 7)]
        public DateTime? DateFirstPurchase { get; set; }

        [StringLength(50)]
        [DataMember(Order = 8)]
        public string EmailAddress { get; set; }

        [StringLength(40)]
        [DataMember(Order = 9)]
        public string EnglishEducation { get; set; }

        [StringLength(100)]
        [DataMember(Order = 10)]
        public string EnglishOccupation { get; set; }

        [StringLength(50)]
        [DataMember(Order = 11)]
        public string FirstName { get; set; }

        [StringLength(40)]
        [DataMember(Order = 12)]
        public string FrenchEducation { get; set; }

        [StringLength(100)]
        [DataMember(Order = 13)]
        public string FrenchOccupation { get; set; }

        [StringLength(1)]
        [DataMember(Order = 14)]
        public string Gender { get; set; }

        [DataMember(Order = 15)]
        virtual public Geography Geography { get; set; }

        [DataMember(Order = 16)]
        public int? GeographyKey { get; set; }

        [StringLength(1)]
        [DataMember(Order = 17)]
        public string HouseOwnerFlag { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [DataMember(Order = 18)]
        virtual public ICollection<InternetSale> InternetSales { get; set; }

        [StringLength(50)]
        [DataMember(Order = 19)]
        public string LastName { get; set; }

        [StringLength(1)]
        [DataMember(Order = 20)]
        public string MaritalStatus { get; set; }

        [StringLength(50)]
        [DataMember(Order = 21)]
        public string MiddleName { get; set; }

        [DataMember(Order = 22)]
        public bool? NameStyle { get; set; }

        [DataMember(Order = 23)]
        public byte? NumberCarsOwned { get; set; }

        [DataMember(Order = 24)]
        public byte? NumberChildrenAtHome { get; set; }

        [StringLength(20)]
        [DataMember(Order = 25)]
        public string Phone { get; set; }

        [StringLength(40)]
        [DataMember(Order = 26)]
        public string SpanishEducation { get; set; }

        [StringLength(100)]
        [DataMember(Order = 27)]
        public string SpanishOccupation { get; set; }

        [StringLength(10)]
        [DataMember(Order = 28)]
        public string Suffix { get; set; }

        [StringLength(8)]
        [DataMember(Order = 29)]
        public string Title { get; set; }

        [DataMember(Order = 30)]
        public byte? TotalChildren { get; set; }

        [Column(TypeName = "money")]
        [DataMember(Order = 31)]
        public decimal? YearlyIncome { get; set; }
    }
}