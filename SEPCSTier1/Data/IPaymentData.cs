using System.Threading.Tasks;
using SEPCSTier1.Models;

namespace SEPCSTier1.Data
{
    public interface IPaymentData
    {
        Task<Payment> AddPayment(Payment payment);

        Task<Payment> GetPaymentByUserId(long id);

        Task<Payment> GetPaymentByName(string name);

        Task<long> GetPaymentId(string name);
    }
}