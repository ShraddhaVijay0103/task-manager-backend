using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebApi.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        // 🔗 Foreign Key → User
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; } = null!;
    }
}
