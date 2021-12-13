using System.ComponentModel.DataAnnotations;

namespace SEPCSTier1.Models
{
    public class Payment
    {
        public long id { get; set; }
        
       
        public string name { get; set; }
        
      
        public string cardnumber { get; set; }
        
       
        public string expirationdate { get; set; }
        
       
        public string securitycode { get; set; }
        
        
        public Payment( string name, string cardnumber, string expirationdate, string securitycode)
        {
            this.name = name;
            this.cardnumber = cardnumber;
            this.expirationdate = expirationdate;
            this.securitycode = securitycode;
         
        }

        public Payment()
        {
        }
    }
}