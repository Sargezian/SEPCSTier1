using System.ComponentModel.DataAnnotations;

namespace SEPCSTier1.Models
{
    public class User
    {
        
        public long id { get; set; }
        
        [Required]
        [StringLength(30, ErrorMessage = "Username too long (30 character limit).")]
        public string username { get; set; }
        
        [Required]
        [StringLength(30, ErrorMessage = "Password too long (30 character limit).")]
        public string password { get; set; }
        
        [Required]
        [Range(1, 10, ErrorMessage = "SecurityLevel invalid (1-10)")]
        public long SecurityLevel { get; set; }
        
        
        
        
    }
}