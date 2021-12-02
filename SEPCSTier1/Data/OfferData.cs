using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEPCSTier1.Graphql;
using SEPCSTier1.Models;

namespace SEPCSTier1.Data
{
    public class OfferData : IOfferData
    {
        private GraphqlClient graphqlClient;
        private List<SaleOffer> Itemslist = new List<SaleOffer>();

        public OfferData(GraphqlClient graphqlClient)
        {
            this.graphqlClient = graphqlClient;
        }


        public async Task<IList<SaleOffer>> GetOffers()
        {
            var result = await graphqlClient.GetSaleOffer.ExecuteAsync();

            
            Itemslist = result.Data.Offers.Select(offer => new SaleOffer()
            {
                id = offer.Id,
                sale_price = offer.Sale_price,
                item_id = offer.Item_id,
                wallet_id = offer.Wallet_id
            }).ToList();
            
            return Itemslist;
        }

        
        public async Task<SaleOffer> GetOfferById(long id)
        {
            var result = await graphqlClient.OfferById.ExecuteAsync(id);
           

            SaleOffer itemss = new SaleOffer()
            {
                id = result.Data.OfferById.Id,
                sale_price = result.Data.OfferById.Sale_price,
                item_id = result.Data.OfferById.Item_id,
                wallet_id = result.Data.OfferById.Wallet_id
            };
            
            return itemss;
        }

        public async void AddSaleOffer(SaleOffer saleOffer)
        {
            await graphqlClient.AddSaleOffer.ExecuteAsync(saleOffer.id, saleOffer.item_id,saleOffer.sale_price,saleOffer.wallet_id);
           
        }
    }
}