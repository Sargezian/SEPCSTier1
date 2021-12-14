using System.ComponentModel.DataAnnotations;

namespace SEPCSTier1.Models
{
    public class Payment
    {
        public long id { get; set; }
        
        [Required(ErrorMessage = "CardholderName cannot be empty")]
        [MinLength(4, ErrorMessage = "CardholderName cannot be less than 4")]
        [MaxLength(12, ErrorMessage = "CardholderName cannot be more than 12")]
        public string name { get; set; }
        
        [Required(ErrorMessage = "CardNumber cannot be empty")]
        [MinLength(16, ErrorMessage = "CardNumber must contain 16 characters")]
        [MaxLength(16, ErrorMessage = "CardNumber must contain 16 characters")]
        public string cardnumber { get; set; }
        
        [Required(ErrorMessage = "ExpirationDate cannot be empty")]
        public string expirationdate { get; set; }
        
        [Required(ErrorMessage = "CVV must contain more than 0 characters")]
        [MinLength(3, ErrorMessage = "CVV must contain  3 characters")]
        [MaxLength(3, ErrorMessage = "CVV must contain  3 characters")]
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