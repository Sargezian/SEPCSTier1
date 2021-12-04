
using System.Threading.Tasks;
using SEPCSTier1.Graphql;
using SEPCSTier1.Models;

namespace SEPCSTier1.Data
{
    public class PaymentData : IPaymentData
    {
        private GraphqlClient graphqlClient;

        public PaymentData(GraphqlClient graphqlClient)
        {
            this.graphqlClient = graphqlClient;
        }
        public async void AddPayment(Payment payment)
        {
            await graphqlClient.AddPayments.ExecuteAsync(payment.name, payment.cardnumber, payment.expirationdate,payment.securitycode,payment.user_id);
        }
        
        
        public async Task<Payment> GetPaymentByUserId(long id)
        {
            var result = await graphqlClient.GetPaymentByUserId.ExecuteAsync(id);
            
            Payment payment = new Payment
            {
                id = result.Data.PaymentByUserId.Id,
                cardnumber = result.Data.PaymentByUserId.Cardnumber,
                expirationdate = result.Data.PaymentByUserId.Expirationdate,
                name = result.Data.PaymentByUserId.Name,
                securitycode = result.Data.PaymentByUserId.Securitycode
            };

            
            return payment;
        }

            
        }

    }
    

