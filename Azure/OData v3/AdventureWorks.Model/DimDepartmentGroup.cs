namespace AdventureWorks.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DimDepartmentGroup")]
    public partial class DimDepartmentGroup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DimDepartmentGroup()
        {
            DimDepartmentGroup1 = new HashSet<DimDepartmentGroup>();
            FactFinances = new HashSet<FactFinance>();
        }

        [Key]
        public int DepartmentGroupKey { get; set; }

        public int? ParentDepartmentGroupKey { get; set; }

        [StringLength(50)]
        public string DepartmentGroupName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DimDepartmentGroup> DimDepartmentGroup1 { get; set; }

        public virtual DimDepartmentGroup DimDepartmentGroup2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FactFinance> FactFinances { get; set; }
    }
}
