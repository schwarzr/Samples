using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WhatsNew.Model.Translation;

namespace WhatsNew.Model
{
    public class Customer : Translation.ITranslatable
    {
        public Customer()
        {
            Invoices = new HashSet<Invoice>();
        }

        public Address HomeAddress { get; set; }

        public int Id { get; set; }

        public ICollection<Invoice> Invoices { get; set; }

        [StringLength(200)]
        [Required]
        public string Name
        {
            get => this.Translation.Get<string>(nameof(Name));
            set => this.Translation.Set<string>(nameof(Name), value, "de", "en");
        }

        public TranslationStore Translation { get; } = new TranslationStore();

        public Address WorkAddress { get; set; }
    }
}