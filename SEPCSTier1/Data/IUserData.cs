using System.Collections.Generic;
using System.Threading.Tasks;
using SEPCSTier1.Models;

namespace SEPCSTier1.Data
{
    public interface IUserData
    {
        void AddUser(User user);
        
        Task<IList<User>> GetUsers();
        
    }
}