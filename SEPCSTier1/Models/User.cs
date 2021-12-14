using System.ComponentModel.DataAnnotations;

namespace SEPCSTier1.Models
{
    public class User
    {
        public long id { get; set; }

        [Required]
        [MinLength(4, ErrorMessage = "username must be more then 3 characters")]
        [MaxLength(14, ErrorMessage = "username can not be more then 12 characters")]
        public string username { get; set; }

        [Required]
        [MinLength(8,ErrorMessage = "password must be more then 8 characters")]
        [MaxLength(14,ErrorMessage = "password can not be more then 16 characters")]

        public string password { get; set; }

        [Required]
        public long SecurityLevel { get; set; }
    }
}