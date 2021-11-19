using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
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
                Query = "mutation ($name: String!,$cardnumber: String!,$expirationdate: String!,$securitycode: String!) {addPayment(name: $name,cardnumber: $cardnumber,expirationdate: $expirationdate,securitycode: $securitycode) {name,cardnumber,expirationdate,securitycode}}",
                Variables = new
                {
                    name = payment.name,
                    cardnumber = payment.cardnumber,
                    expirationdate = payment.expirationdate,
                    securitycode = payment.securitycode,
                    
                }
            };

            await client.SendMutationAsync<ResponsePaymentType>(request);
        }
        
        
        }
    
}