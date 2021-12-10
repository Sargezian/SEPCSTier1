using System.ComponentModel.DataAnnotations;

namespace SEPCSTier1.Models
{
    public class Product
    {
        public long id { get; set; }
        public long item_id { get; set; }
        public long saleOffer_id { get; set; }
        
        [Required]
        [StringLength(100, ErrorMessage = "Weaponname too long (100 character limit).")]
        public string weaponname { get; set; }
        
        [Required]
        [StringLength(10000, ErrorMessage = "weaponURL too long (10000 character limit).")]
        public string weaponURL { get; set; }
        
        [Required]
        [Range(1, 1000000, ErrorMessage = "Sale_price invalid (1-1000000)")]
        public int sale_price { get; set; }
        public long wallet_id { get; set; }
    }
}