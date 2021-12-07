using System.ComponentModel.DataAnnotations;

namespace SEPCSTier1.Models
{
    public class Payment
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string cardnumber { get; set; }
        [Required]
        public string expirationdate { get; set; }
        [Required]
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