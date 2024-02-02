using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime MyProperty { get; set; }
    }
}
