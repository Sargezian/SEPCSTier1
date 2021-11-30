using System.ComponentModel.DataAnnotations;

namespace SEPCSTier1.Models
{
    public class User
    {
        
        public long id { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        
        public string firstName { get; set; }
        
        public string lastName { get; set; }
        
        
        
        
        
    }
}