
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
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

        public async Task<IList<User>> ValidateUser(string userName, string passWord)
        {
            
            using var client = new GraphQLHttpClient("https://localhost:5001/graphql"
                ,new NewtonsoftJsonSerializer());

            var request = new GraphQLRequest
            {
                Query = "query ($username: String!,$password:String!) {users(where: { username: { eq: $username },password:{eq:$password} }) {id,username,password}}",
                Variables = new
                {
                    username = userName,
                    password = passWord
                }
            };
            
            
            var response =  await client.SendQueryAsync<ResponseUserCollectionType>(request);

            if (!response.Data.Users.Any())
            {
                throw new Exception("user not found");
            }
           
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