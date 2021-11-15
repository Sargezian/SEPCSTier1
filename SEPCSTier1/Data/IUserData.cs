using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorTailwind.Models;

namespace BlazorTailwind.Data
{
    public interface IUserData
    {
        void AddUser(User user);
        
        Task<IList<User>> GetUsers();
        
    }
}