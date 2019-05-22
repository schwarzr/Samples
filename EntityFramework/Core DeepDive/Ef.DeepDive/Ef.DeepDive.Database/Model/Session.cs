using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ef.DeepDive.Database.Model
{
    public class Session
    {
        public Guid Id { get; set; }

        public Guid SpeakerId { get; set; }

        public Speaker Speaker { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [StringLength(2000)]
        public string Description { get; set; }

        public decimal Rating { get; set; }
    }
}
