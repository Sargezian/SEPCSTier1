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

        
        public async Task<IList<SaleOffer>> GetOfferByUserId(long id)
        {
            // var result = await graphqlClient.OfferByUserId.ExecuteAsync(id);
            //
            //
            // SaleOffer itemss = new SaleOffer()
            // {
            //     id = result.Data.OfferByUserId.Id,
            //     sale_price = result.Data.OfferByUserId.Sale_price,
            //     item_id = result.Data.OfferByUserId.Item_id,
            //     wallet_id = result.Data.OfferByUserId.Wallet_id
            //     
            // };
            //
            return null;
        }
        
        
        
        public async Task<SaleOffer> GetOfferBySaleOfferId(long id)
        {
            var result = await graphqlClient.OfferBySaleOfferId.ExecuteAsync(id);
            
            
            SaleOffer itemss = new SaleOffer()
            {
                id = result.Data.OfferBySaleOfferId.Id,
                sale_price = result.Data.OfferBySaleOfferId.Sale_price,
                item_id = result.Data.OfferBySaleOfferId.Item_id,
                wallet_id = result.Data.OfferBySaleOfferId.Wallet_id
                
            };
            
            return itemss;
        }

        public async Task AddSaleOffer(SaleOffer saleOffer)
        {
            var result = await graphqlClient.AddSaleOffer.ExecuteAsync(saleOffer.item_id,
                saleOffer.sale_price, saleOffer.wallet_id);

        }
       
    }
}