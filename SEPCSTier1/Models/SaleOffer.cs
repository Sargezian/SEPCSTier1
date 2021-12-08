namespace SEPCSTier1.Models
{
    public class SaleOffer
    {
        public long id { get; set; }
        public long item_id { get; set; }
        public int sale_price { get; set; }
        public long wallet_id { get; set; }
        
        public long user_id { get; set; }
    }
}