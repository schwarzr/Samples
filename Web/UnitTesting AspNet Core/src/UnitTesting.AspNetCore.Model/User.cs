using System.ComponentModel.DataAnnotations;

namespace UnitTesting.DotNetCore.Model
{
    public class User
    {
        public int Id { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }
    }
}