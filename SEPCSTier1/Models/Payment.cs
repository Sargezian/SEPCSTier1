using System.ComponentModel.DataAnnotations;

namespace SEPCSTier1.Models
{
    public class Payment
    {
        public long id { get; set; }
        
        [Required]
        [StringLength(30, ErrorMessage = "Name too long (30 character limit).")]
        public string name { get; set; }
        
        [Required]
        [StringLength(16, ErrorMessage = "Cardnumber too long (16 character limit).")]
        public string cardnumber { get; set; }
        
        [Required]
        [StringLength(16, ErrorMessage = "expirationdate too long (16 character limit).")]
        public string expirationdate { get; set; }
        
        [Required]
        [StringLength(16, ErrorMessage = "securitycode too long (3 character limit).")]
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