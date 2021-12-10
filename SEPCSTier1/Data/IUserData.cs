using System.Collections.Generic;
using System.Threading.Tasks;
using SEPCSTier1.Models;

namespace SEPCSTier1.Data
{
    public interface IUserData
    {
        Task<User> AddUser(User user);
        
        void RemoveAccount(long UserId);
        
        Task<IList<User>> GetUsers();
        Task<User> ValidateUser(string userName, string passWord);
        
        Task<User> GetUserByID(long id);


        Task<User> UpdateUser(User user, long id);


        Task<User> GetUserBySaleOfferId(long id);
    }
}