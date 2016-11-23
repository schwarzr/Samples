using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.WebApi.Model
{
    public class FileReference
    {
        public Guid Id { get; set; }

        [MaxLength(255)]
        [Required]
        public string Name { get; set; }

        [MaxLength(500)]
        [Required]
        public string Path { get; set; }

        public FileType FileType { get; set; }

        public User Author { get; set; }

        public int AuthorId { get; set; }
    }
}
