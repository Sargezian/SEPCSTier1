
using System.Collections.Generic;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using SEPCSTier1.Models;

namespace SEPCSTier1.Data
{
    public class UserJSONData : IUserData
    {
        public async void RemoveAccount(int UserId)
        {
            using var client = new GraphQLHttpClient("https://localhost:5001/graphql"
                , new NewtonsoftJsonSerializer());
            
            var request = new GraphQLRequest
            {
                Query = "mutation($id:Int!) {deleteUser(id:$id)}",
                Variables = new
                {
                    id = UserId
                }
            };

            await client.SendMutationAsync<ResponseUserType>(request);
        }

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
            using var client = new GraphQLHttpClient("https://localhost:5001/graphql"
                , new NewtonsoftJsonSerializer());
            
            var request = new GraphQLRequest
            {
                Query =
                    "mutation ($username: String!, $password: String!) {addUser(username: $username, password: $password) {username,password}}",
                Variables = new
                {
                    username = user.username,
                    password = user.password
                }
            };

            await client.SendMutationAsync<ResponseUserType>(request);
            
        }
    }
}