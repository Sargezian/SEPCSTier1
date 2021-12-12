using System.ComponentModel.DataAnnotations;

namespace SEPCSTier1.Models
{
    public class ShowShoppingCart
    {

        public long  sale_offer_id { get; set; }

        public long item_id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Weaponname too long (100 character limit).")]
        public string weaponname { get; set; }

        [Required]
        [Range(1, 1000000, ErrorMessage = "Sale_price invalid (1-1000000)")]
        public long sale_price { get; set; }
        
        
        
        
        
        
    }
}