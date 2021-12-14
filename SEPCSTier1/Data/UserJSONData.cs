using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.WebEncoders.Testing;
using SEPCSTier1.Graphql;
using SEPCSTier1.Models;
using StrawberryShake;
using StrawberryShake.Extensions;

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


        public async Task RemoveAccount(long UserId)
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
                password = users.Password,
                SecurityLevel = users.Securitylevel
            }).ToList();
                
            return userList;
        }

        public async Task<User> ValidateUser(string userName, string passWord)
        {
           
            if(userName != null){
                var result = await graphqlClient.ValidateUser.ExecuteAsync(userName, passWord);

                if (result.IsErrorResult())
                {
                    throw new Exception("User not found");
                }

                User user = new User
                {
                    id = result.Data.ValidateUser.Id,
                    username = result.Data.ValidateUser.Username,
                    password = result.Data.ValidateUser.Password,
                    SecurityLevel = result.Data.ValidateUser.Securitylevel
                    
                };
                return user;
            }
            
                return null;
        }

        public async Task<User> AddUser(User user)
        {
           var result = await graphqlClient.AddUser.ExecuteAsync(user.username, user.password);
           
           
           return user;
        }
        
        public async Task<User> GetUserByID(long Id)
        {
            var result = await graphqlClient.UserById.ExecuteAsync(Id);
           

            User user = new User
            {
                id = result.Data.UserById.Id,
                username = result.Data.UserById.Username,
                password = result.Data.UserById.Password,
                SecurityLevel = result.Data.UserById.Securitylevel

            };
           
            return user;
        }



        public async Task<User> GetUserBySaleOfferId(long id)
        {
            var result = await graphqlClient.GetUserBySaleOfferId.ExecuteAsync(id);

            User user = new User
            {
               username = result.Data.UserBySaleOfferId.Username
            };


            return user;
        }



        public async Task<User> UpdateUser(User user,long id)
        {
            await graphqlClient.UpdateUser.ExecuteAsync(id,user.username,user.password,user.SecurityLevel);
            
            return user;

        }
    }
}