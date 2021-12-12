
namespace SEPCSTier1.Models
{
    public class Wallet
    {
        public long id { get; set; }
        
        public int balance { get; set; }
        public long creditcard_id { get; set; }
        public long user_id { get; set; }

        public Wallet()
        {
            
        }
        public Wallet(int balance, long userId)
        {
            this.balance = balance;
            user_id = userId;
        }
        
        
    }
}