using System.ComponentModel.DataAnnotations;

namespace ContactAppWeb.Models
{
    public class Contact
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public int Phone { get; set; }
    }
}
