
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
            await graphqlClient.AddPayment.ExecuteAsync(payment.name, payment.cardnumber, payment.expirationdate,payment.securitycode);
        }

            
        }

    }
    

