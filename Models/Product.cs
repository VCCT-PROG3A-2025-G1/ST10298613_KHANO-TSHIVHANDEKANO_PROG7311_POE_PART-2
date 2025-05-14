using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PROG7311_POE_PART_2.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string Category { get; set; } = string.Empty;

        [Required]
        public DateTime ProductionDate { get; set; }

        [Required]
        public int FarmerId { get; set; }

        [ForeignKey("FarmerId")]
        public Farmer Farmer { get; set; }
    }
}