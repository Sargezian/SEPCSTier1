namespace SEPCSTier1.Models
{
    public class Payment
    {
        public int id { get; set; }
        public string name { get; set; }
        public string cardNumber { get; set; }
        public string expirationDate { get; set; }
        public string securityCode { get; set; }
    }
}