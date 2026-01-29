using System.ComponentModel.DataAnnotations;

namespace MyWebApi.Models
{
    public class CreateCategoryRequest
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
