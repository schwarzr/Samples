using System.ComponentModel.DataAnnotations;

namespace WhatsNew.Model
{
    public class Invoice
    {
        public decimal Amount { get; set; }

        public Customer Customer { get; set; }

        public int CustomerId { get; set; }

        public int Id { get; set; }

        [StringLength(200)]
        [Required]
        public string InvoiceNumber { get; set; }
    }
}