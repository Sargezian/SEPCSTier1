using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEPCSTier1.Graphql;
using SEPCSTier1.Models;
using SEPCSTier1.Pages;

namespace SEPCSTier1.Data
{
    public class ShoppingCartData : IShoppingCartData
    {
        private GraphqlClient graphqlClient;

        private List<ShowShoppingCart> shoppingCarts = new List<ShowShoppingCart>();


        public ShoppingCartData(GraphqlClient graphqlClient)
        {
            this.graphqlClient = graphqlClient;
        }


        public async Task<long> GetCartCountById(long id)
        {
            var result = await graphqlClient.GetCartById.ExecuteAsync(id);


            return result.Data.CartCountById;
        }

        public async Task<IList<ShowShoppingCart>> GetShoppingCartById(long id)
        {
            var result = await graphqlClient.GetShoppingCart.ExecuteAsync(id);

            shoppingCarts = result.Data.ShoppingCartById.Select(shop => new ShowShoppingCart
            {
                sale_offer_id = shop.Sale_offer_id,
                item_id = shop.Item_id,
                sale_price = shop.Sale_price,
                weaponname = shop.Weaponname
            }).ToList();


            return shoppingCarts;
        }


        public async void AddShoppingCart(ShoppingCarts shoppingCarts)
        {
            await graphqlClient.AddShoppingCart.ExecuteAsync(shoppingCarts.saleOfferId, shoppingCarts.userId);
        }
        
        

        public async Task<long> GetTotalPrice(long id)
        {
            var result = await graphqlClient.GetTotalPriceById.ExecuteAsync(id);

            return result.Data.TotalPriceById;
        }
    }
}