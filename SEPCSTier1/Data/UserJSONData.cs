using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEPCSTier1.Graphql;
using SEPCSTier1.Models;
using StrawberryShake;

namespace SEPCSTier1.Data
{
    public class UserJSONData : IUserData
    {
        private GraphqlClient graphqlClient;
        private List<User> userList = new List<User>();


        public UserJSONData(GraphqlClient graphqlClient)
        {
            this.graphqlClient = graphqlClient;
        }


        public async void RemoveAccount(long UserId)
        {
            await graphqlClient.DeleteUser.ExecuteAsync(UserId);
        }

        public async Task<IList<User>> GetUsers()
        {
            var result = await graphqlClient.GetUsers.ExecuteAsync();

            userList = result.Data.Users.Select(users => new User
            {
                id = users.Id,
                username = users.Username,
                password = users.Password
            }).ToList();

            return userList;
        }

        public async Task<User> ValidateUser(string userName, string passWord)
        {
           
                var result = await graphqlClient.ValidateUser.ExecuteAsync(userName, passWord);

                if (result.IsErrorResult())
                {
                    throw new Exception("User not found");
                }

                User user = new User
                {
                    id = result.Data.ValidateUser.Id,
                    username = result.Data.ValidateUser.Username,
                    password = result.Data.ValidateUser.Password
                };
                
                return user;
        }

        public async Task<User> AddUser(User user)
        {
           var result = await graphqlClient.AddUser.ExecuteAsync(user.username, user.password);

           return user;
        }
        
        public async Task<User> GetUserByID(long Id)
        {
            /*var result = await graphqlClient.UserById.ExecuteAsync(Id);
           

            User user = new User
            {
                id = result.Data.UserById.Id,
                username = result.Data.UserById.Username
                
            };
           */
            return null;
        }
    }
}