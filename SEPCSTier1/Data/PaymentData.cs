using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using SEPCSTier1.Models;

namespace SEPCSTier1.Data
{
    public class PaymentData : IPaymentData
    {
        public async void AddPayment(Payment payment)
        {
            using var client = new GraphQLHttpClient("https://localhost:5001/graphql"
                , new NewtonsoftJsonSerializer());

            var request = new GraphQLRequest
            {
                Query =
                    "mutation ($name: String!, $cardNumber: String!, $expirationDate: String!, $securityCode: String!) {addPayment(name: $name, cardNumber: $cardNumber,expirationDate: $expirationDate,securityCode: $securityCode) {name,cardNumber,expirationDate,securityCode}}",
                Variables = new
                {
                    name = payment.name,
                    cardNumber = payment.cardNumber,
                    expirationDate = payment.expirationDate,
                    securityCode = payment.securityCode
                }
            };

            await client.SendMutationAsync<ResponseUserType>(request);
        }
        
        
        }
    
}