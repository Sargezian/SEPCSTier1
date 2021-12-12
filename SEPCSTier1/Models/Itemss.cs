using System.ComponentModel.DataAnnotations;

namespace SEPCSTier1.Models
{
    public class Itemss
    {
        public long id { get; set; }
        
        [Required]
        [StringLength(100, ErrorMessage = "Weaponname too long (100 character limit).")]
        public string weaponname { get; set; }
        
        [Required]
        [StringLength(10000, ErrorMessage = "weaponURL too long (10000 character limit).")]
        public string weaponURL { get; set; }
    }
}