using System.Collections.Generic;
using System.Threading.Tasks;
using SEPCSTier1.Models;

namespace SEPCSTier1.Data
{
    public interface IItemData
    {
        Task<IList<Itemss>> GetItems();

        Task<IList<Itemss>> GetItemByID(long id);

        
    }
}