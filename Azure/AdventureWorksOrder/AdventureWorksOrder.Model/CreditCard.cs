using System;
using System.Collections.Generic;

namespace AdventureWorksOrder.Model
{
    public partial class CreditCard
    {
        public CreditCard()
        {
            PersonCreditCard = new HashSet<PersonCreditCard>();
            SalesOrderHeader = new HashSet<SalesOrderHeader>();
        }

        public string CardNumber { get; set; }

        public string CardType { get; set; }

        public int CreditCardId { get; set; }

        public byte ExpMonth { get; set; }

        public short ExpYear { get; set; }

        public DateTime ModifiedDate { get; set; }

        public ICollection<PersonCreditCard> PersonCreditCard { get; set; }

        public ICollection<SalesOrderHeader> SalesOrderHeader { get; set; }
    }
}