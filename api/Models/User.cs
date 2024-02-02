using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class User : BaseModel
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        public List<Recipe> Recipes { get; set; } = new List<Recipe>();
    }
}
