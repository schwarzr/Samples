namespace AdventureWorks.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FactAdditionalInternationalProductDescription")]
    public partial class FactAdditionalInternationalProductDescription
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductKey { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string CultureName { get; set; }

        [Required]
        public string ProductDescription { get; set; }
    }
}
