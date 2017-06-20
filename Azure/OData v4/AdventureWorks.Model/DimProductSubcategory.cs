namespace AdventureWorks.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DimProductSubcategory")]
    public partial class DimProductSubcategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DimProductSubcategory()
        {
            DimProducts = new HashSet<DimProduct>();
        }

        [Key]
        public int ProductSubcategoryKey { get; set; }

        public int? ProductSubcategoryAlternateKey { get; set; }

        [Required]
        [StringLength(50)]
        public string EnglishProductSubcategoryName { get; set; }

        [Required]
        [StringLength(50)]
        public string SpanishProductSubcategoryName { get; set; }

        [Required]
        [StringLength(50)]
        public string FrenchProductSubcategoryName { get; set; }

        public int? ProductCategoryKey { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DimProduct> DimProducts { get; set; }

        public virtual DimProductCategory DimProductCategory { get; set; }
    }
}
