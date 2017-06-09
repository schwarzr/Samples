using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LargeData.Model.Custom
{
    [DataContract(IsReference = true)]
    public class InternetSaleInfo
    {
        [DataMember(Order = 1)]
        public string Currency { get; set; }

        [DataMember(Order = 2)]
        public string Customer { get; set; }

        [DataMember(Order = 3)]
        public string CustomerLocation { get; set; }

        [DataMember(Order = 4)]
        public DateTime? Date { get; set; }

        [DataMember(Order = 5)]
        public string Order { get; set; }

        [DataMember(Order = 6)]
        public byte Pos { get; set; }

        [DataMember(Order = 7)]
        public decimal Price { get; set; }

        [DataMember(Order = 8)]
        public string Promotion { get; set; }

        [DataMember(Order = 9)]
        public short Quantity { get; set; }

        [DataMember(Order = 10)]
        public decimal Total { get; set; }
    }
}