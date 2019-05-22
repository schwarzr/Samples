using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ef.DeepDive.Database.Model
{
    public class Speaker
    {
        public Speaker()
        {
            this.Sessions = new HashSet<Session>();
        }

        public Guid Id { get; set; }

        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }


        [Required]
        [StringLength(255)]
        public string LastName { get; set; }


        [StringLength(400)]
        public string Company { get; set; }

        public ICollection<Session> Sessions { get; }
    }
}
