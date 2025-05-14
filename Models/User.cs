using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PROG7311_POE_PART_2.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty; 

        [Required]
        public string Role { get; set; } = string.Empty; // "Farmer" or "Employee"

        public int? FarmerId { get; set; }

        [ForeignKey("FarmerId")]
        public Farmer? Farmer { get; set; }
    }
}

