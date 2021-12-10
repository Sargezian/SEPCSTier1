using System.ComponentModel.DataAnnotations;

namespace SEPCSTier1.Models
{
    public class SoldOffer
    {
        public long id { get; set; }
        public long item_id { get; set; }
        public long order_id { get; set; }
        
        [Required]
        [Range(1, 1000000, ErrorMessage = "Sale_price invalid (1-1000000)")]
        public int sale_price { get; set; }
        public long seller_wallet_id { get; set; }
    }
}