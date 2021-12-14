using System;
using System.ComponentModel.DataAnnotations;

namespace SEPCSTier1.Models
{
    public class SaleOffer
    {
        public long id { get; set; }
        [Required]
        public long item_id { get; set; }

        [Required, Range(100, 1000000, ErrorMessage = "sale price must be more than 100")]
        public int sale_price { get; set; }
        public long wallet_id { get; set; }
        public bool available { get; set; }
        
       
    }
}