namespace AdventureWorks.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DimOrganization")]
    public partial class DimOrganization
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DimOrganization()
        {
            DimOrganization1 = new HashSet<DimOrganization>();
            FactFinances = new HashSet<FactFinance>();
        }

        [Key]
        public int OrganizationKey { get; set; }

        public int? ParentOrganizationKey { get; set; }

        [StringLength(16)]
        public string PercentageOfOwnership { get; set; }

        [StringLength(50)]
        public string OrganizationName { get; set; }

        public int? CurrencyKey { get; set; }

        public virtual DimCurrency DimCurrency { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DimOrganization> DimOrganization1 { get; set; }

        public virtual DimOrganization DimOrganization2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FactFinance> FactFinances { get; set; }
    }
}
