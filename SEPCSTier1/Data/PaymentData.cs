
using System;
using System.Threading.Tasks;
using SEPCSTier1.Graphql;
using SEPCSTier1.Models;
using StrawberryShake;

namespace SEPCSTier1.Data
{
    public class PaymentData : IPaymentData
    {
        private GraphqlClient graphqlClient;

        public PaymentData(GraphqlClient graphqlClient)
        {
            this.graphqlClient = graphqlClient;
        }
        public async Task<Payment> AddPayment(Payment payment)
        {
            var result = await graphqlClient.AddPayment.ExecuteAsync(payment.name, payment.cardnumber, payment.expirationdate,
                payment.securitycode);
            if (result.IsErrorResult())
            {
                throw new Exception("something went wrong payment");
            }

            return payment;
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

        public async Task<long> GetPaymentId(string name)
        {

            var payment = await GetPaymentByName(name);

            return payment.id;


        }
        
        
        
        

        public async Task<Payment> GetPaymentByName(string name)
        {
            var result = await graphqlClient.PaymentByName.ExecuteAsync(name);

            var Payment = new Payment
            {
                id = result.Data.PaymentByName.Id,
                name = result.Data.PaymentByName.Name,
                cardnumber = result.Data.PaymentByName.Cardnumber,
                expirationdate = result.Data.PaymentByName.Expirationdate,
                securitycode = result.Data.PaymentByName.Securitycode,
              
            };


            return Payment;
        }
    }

    }
    

