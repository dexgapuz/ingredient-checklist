using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Ingredient : BaseModel
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        public required Recipe Recipe { get; set; }
    }
}
