using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEPCSTier1.Graphql;
using SEPCSTier1.Models;

namespace SEPCSTier1.Data
{
    public class SoldOfferData : ISoldOfferData
    {
        private GraphqlClient graphqlClient;
        private List<SoldOffer> Itemslist = new List<SoldOffer>();

        public SoldOfferData(GraphqlClient graphqlClient)
        {
            this.graphqlClient = graphqlClient;
        }


        public async Task<IList<SoldOffer>> GetSoldOffers()
        {
            var result = await graphqlClient.GetSoldOffer.ExecuteAsync();

            
            Itemslist = result.Data.AllSoldOffer.Select(offer => new SoldOffer()
            {
                id = offer.Id,
                sale_price = offer.Sale_price,
                item_id = offer.Item_id,
                seller_wallet_id = offer.Seller_wallet_id,
                order_id = offer.Order_id
            }).ToList();
            
            return Itemslist;
        }

        
        public async Task<SoldOffer> GetSoldOfferById(long id)
        {
            var result = await graphqlClient.GetSoldOfferById.ExecuteAsync(id);
           

            SoldOffer itemss = new SoldOffer()
            {
                id = result.Data.GetSoldOfferById.Id,
                sale_price = result.Data.GetSoldOfferById.Sale_price,
                item_id = result.Data.GetSoldOfferById.Item_id,
                seller_wallet_id = result.Data.GetSoldOfferById.Seller_wallet_id,
                order_id = result.Data.GetSoldOfferById.Order_id
            };
            
            return itemss;
        }

        public async void AddSoldOffer(SoldOffer saleOffer)
        {
            var result = await graphqlClient.AddSoldOffer.ExecuteAsync(saleOffer.item_id, saleOffer.order_id, saleOffer.sale_price, saleOffer.seller_wallet_id);
        }
       
    }
}