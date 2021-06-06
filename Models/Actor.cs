using System.ComponentModel.DataAnnotations;

namespace Cine.Models
{
    public class Actor : Producer
    {
        [Required]
        [RegularExpression("Principal|Secundario|Extra", 
        ErrorMessage="Los roles posibles son: Principal, Secundario o Extra")]
        public string Role { get; set;  }
    }
}