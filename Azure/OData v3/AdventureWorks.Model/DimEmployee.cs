namespace AdventureWorks.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DimEmployee")]
    public partial class DimEmployee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DimEmployee()
        {
            DimEmployee1 = new HashSet<DimEmployee>();
            FactResellerSales = new HashSet<FactResellerSale>();
            FactSalesQuotas = new HashSet<FactSalesQuota>();
        }

        [Key]
        public int EmployeeKey { get; set; }

        public int? ParentEmployeeKey { get; set; }

        [StringLength(15)]
        public string EmployeeNationalIDAlternateKey { get; set; }

        [StringLength(15)]
        public string ParentEmployeeNationalIDAlternateKey { get; set; }

        public int? SalesTerritoryKey { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string MiddleName { get; set; }

        public bool NameStyle { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [Column(TypeName = "date")]
        public DateTime? HireDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BirthDate { get; set; }

        [StringLength(256)]
        public string LoginID { get; set; }

        [StringLength(50)]
        public string EmailAddress { get; set; }

        [StringLength(25)]
        public string Phone { get; set; }

        [StringLength(1)]
        public string MaritalStatus { get; set; }

        [StringLength(50)]
        public string EmergencyContactName { get; set; }

        [StringLength(25)]
        public string EmergencyContactPhone { get; set; }

        public bool? SalariedFlag { get; set; }

        [StringLength(1)]
        public string Gender { get; set; }

        public byte? PayFrequency { get; set; }

        [Column(TypeName = "money")]
        public decimal? BaseRate { get; set; }

        public short? VacationHours { get; set; }

        public short? SickLeaveHours { get; set; }

        public bool CurrentFlag { get; set; }

        public bool SalesPersonFlag { get; set; }

        [StringLength(50)]
        public string DepartmentName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        public byte[] EmployeePhoto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DimEmployee> DimEmployee1 { get; set; }

        public virtual DimEmployee DimEmployee2 { get; set; }

        public virtual DimSalesTerritory DimSalesTerritory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FactResellerSale> FactResellerSales { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FactSalesQuota> FactSalesQuotas { get; set; }
    }
}
