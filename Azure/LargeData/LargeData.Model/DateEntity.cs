namespace LargeData.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;

    [Table("DimDate")]
    [DataContract(IsReference = true)]
    public partial class DateEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DateEntity()
        {
            OrderDateSales = new HashSet<InternetSale>();
            DueDateSales = new HashSet<InternetSale>();
            ShipDateSales = new HashSet<InternetSale>();
        }

        [DataMember(Order = 1)]
        public byte CalendarQuarter { get; set; }

        [DataMember(Order = 2)]
        public byte CalendarSemester { get; set; }

        [DataMember(Order = 3)]
        public short CalendarYear { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DataMember(Order = 4)]
        public int DateKey { get; set; }

        [DataMember(Order = 5)]
        public byte DayNumberOfMonth { get; set; }

        [DataMember(Order = 6)]
        public byte DayNumberOfWeek { get; set; }

        [DataMember(Order = 7)]
        public short DayNumberOfYear { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [DataMember(Order = 8)]
        virtual public ICollection<InternetSale> DueDateSales { get; set; }

        [Required]
        [StringLength(10)]
        [DataMember(Order = 9)]
        public string EnglishDayNameOfWeek { get; set; }

        [Required]
        [StringLength(10)]
        [DataMember(Order = 10)]
        public string EnglishMonthName { get; set; }

        [DataMember(Order = 11)]
        public byte FiscalQuarter { get; set; }

        [DataMember(Order = 12)]
        public byte FiscalSemester { get; set; }

        [DataMember(Order = 13)]
        public short FiscalYear { get; set; }

        [Required]
        [StringLength(10)]
        [DataMember(Order = 14)]
        public string FrenchDayNameOfWeek { get; set; }

        [Required]
        [StringLength(10)]
        [DataMember(Order = 15)]
        public string FrenchMonthName { get; set; }

        [Column(TypeName = "date")]
        [DataMember(Order = 16)]
        public DateTime FullDateAlternateKey { get; set; }

        [DataMember(Order = 17)]
        public byte MonthNumberOfYear { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [DataMember(Order = 18)]
        virtual public ICollection<InternetSale> OrderDateSales { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [DataMember(Order = 19)]
        virtual public ICollection<InternetSale> ShipDateSales { get; set; }

        [Required]
        [StringLength(10)]
        [DataMember(Order = 20)]
        public string SpanishDayNameOfWeek { get; set; }

        [Required]
        [StringLength(10)]
        [DataMember(Order = 21)]
        public string SpanishMonthName { get; set; }

        [DataMember(Order = 22)]
        public byte WeekNumberOfYear { get; set; }
    }
}