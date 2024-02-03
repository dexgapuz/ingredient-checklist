using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class User : BaseModel
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public List<Recipe> Recipes { get; set; } = new List<Recipe>();
    }
}
