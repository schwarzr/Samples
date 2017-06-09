namespace LargeData.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;

    [Table("FactInternetSalesReason")]
    [DataContract(IsReference = true)]
    public partial class InternetSalesReason
    {
        [DataMember(Order = 1)]
        virtual public InternetSale InternetSale { get; set; }

        [Key]
        [Column(Order = 1)]
        [DataMember(Order = 2)]
        public byte SalesOrderLineNumber { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        [DataMember(Order = 3)]
        public string SalesOrderNumber { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DataMember(Order = 4)]
        public int SalesReasonKey { get; set; }
    }
}