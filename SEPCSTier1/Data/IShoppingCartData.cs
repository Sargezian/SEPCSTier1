using System.Collections.Generic;
using System.Threading.Tasks;
using SEPCSTier1.Models;

namespace SEPCSTier1.Data
{
    public interface IShoppingCartData
    {
        Task<long> GetCartCountById(long id);

        Task<IList<ShowShoppingCart>> GetShoppingCartById(long id);


        Task AddShoppingCart(ShoppingCarts shoppingCarts);

        Task<long> GetTotalPrice(long id);
        
        
        
        Task RemoveShoppingCart(long userId,long saleOfferId);
    }
}