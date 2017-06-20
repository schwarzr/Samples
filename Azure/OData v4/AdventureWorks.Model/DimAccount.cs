namespace AdventureWorks.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DimAccount")]
    public partial class DimAccount
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DimAccount()
        {
            DimAccount1 = new HashSet<DimAccount>();
            FactFinances = new HashSet<FactFinance>();
        }

        [Key]
        public int AccountKey { get; set; }

        public int? ParentAccountKey { get; set; }

        public int? AccountCodeAlternateKey { get; set; }

        public int? ParentAccountCodeAlternateKey { get; set; }

        [StringLength(50)]
        public string AccountDescription { get; set; }

        [StringLength(50)]
        public string AccountType { get; set; }

        [StringLength(50)]
        public string Operator { get; set; }

        [StringLength(300)]
        public string CustomMembers { get; set; }

        [StringLength(50)]
        public string ValueType { get; set; }

        [StringLength(200)]
        public string CustomMemberOptions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DimAccount> DimAccount1 { get; set; }

        public virtual DimAccount DimAccount2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FactFinance> FactFinances { get; set; }
    }
}
