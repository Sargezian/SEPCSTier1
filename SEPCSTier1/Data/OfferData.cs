using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEP3_tier2.Models;
using SEPCSTier1.Graphql;
using SEPCSTier1.Models;

namespace SEPCSTier1.Data
{
    public class OfferData : IOfferData
    {
        private GraphqlClient graphqlClient;
        private List<SaleOffer> Itemslist = new List<SaleOffer>();
        private IList<SaleOfferWallet> saleOfferWalletList = new List<SaleOfferWallet>();

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
                wallet_id = offer.Wallet_id,
                available = offer.Available
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


        public async Task UpdateSaleOfferToFalse(long id)
        {
            await graphqlClient.UpdateSaleOfferToFalse.ExecuteAsync(id);
        }

        public async Task<IList<SaleOfferWallet>> GetItemsById(long id)
        {
            var result = await graphqlClient.GetItemsById.ExecuteAsync(id);

            saleOfferWalletList = result.Data.ItemsById.Select(item => new SaleOfferWallet()
            {
                sale_offer_id= item.Sale_offer_id,
                weaponname = item.Weaponname,
                weaponURL = item.WeaponURL,
                sale_price = item.Sale_price
                
                
            }).ToList();


            return saleOfferWalletList;
        }
    }
}