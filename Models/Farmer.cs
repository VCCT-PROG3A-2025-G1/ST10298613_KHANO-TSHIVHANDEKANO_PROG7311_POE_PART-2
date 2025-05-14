using System.ComponentModel.DataAnnotations;

namespace PROG7311_POE_PART_2.Models
{
    public class Farmer
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required, MaxLength(100)]
        public string Location { get; set; } = string.Empty;

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}

