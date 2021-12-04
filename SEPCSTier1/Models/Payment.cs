namespace SEPCSTier1.Models
{
    public class Payment
    {
        public int id { get; set; }
        public string name { get; set; }
        public string cardnumber { get; set; }
        public string expirationdate { get; set; }
        public string securitycode { get; set; }
        
        public long user_id { get; set; }

        public Payment( string name, string cardnumber, string expirationdate, string securitycode, long userId)
        {
            this.name = name;
            this.cardnumber = cardnumber;
            this.expirationdate = expirationdate;
            this.securitycode = securitycode;
            user_id = userId;
        }

        public Payment()
        {
        }
    }
}