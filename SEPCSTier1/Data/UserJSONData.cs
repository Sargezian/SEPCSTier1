using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BlazorTailwind.Models;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;

namespace BlazorTailwind.Data
{
    public class UserJSONData : IUserData
    {
        public async Task<IList<User>> GetUsers()
        {
            using var client = new GraphQLHttpClient("https://localhost:5001/graphql"
                , new NewtonsoftJsonSerializer());

            var request = new GraphQLRequest
            {
                Query = "query{users{id,username,password}}"
                
            };
            var response = await client.SendQueryAsync<ResponseUserCollectionType>(request);
            
            return response.Data.Users;
        }
        
        
        public async void AddUser(User user)
        {
            using HttpClient client = new HttpClient();

            var userAsJson = JsonSerializer.Serialize(user);

            HttpContent httpContent = new StringContent(userAsJson, Encoding.UTF8, "application/json");


            HttpResponseMessage httpResponseMessage = await client.PostAsync("http://localhost:8082/user/", httpContent);
            
            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                throw new Exception("failed to add data");
            }

        }
    }
}