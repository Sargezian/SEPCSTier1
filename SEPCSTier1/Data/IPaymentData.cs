using System.Threading.Tasks;
using SEPCSTier1.Models;

namespace SEPCSTier1.Data
{
    public interface IPaymentData
    {
        void AddPayment(Payment payment);

        Task<Payment> GetPaymentByUserId(long id);
    }
}