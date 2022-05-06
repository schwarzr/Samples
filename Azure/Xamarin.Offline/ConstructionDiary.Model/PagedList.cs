using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ConstructionDiary.Model
{
    [DataContract]
    public class PagedList<TElement>
        where TElement : class
    {
        public PagedList(List<TElement> items, int totalCount)
        {
            Items = items;
            TotalCount = totalCount;
        }

        [DataMember]
        public List<TElement> Items { get; set; }

        [DataMember]
        public int TotalCount { get; set; }
    }
}