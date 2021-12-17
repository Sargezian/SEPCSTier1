using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3_tier2.Models;
using SEPCSTier1.Models;

namespace SEPCSTier1.Data
{
    public interface IOfferData
    {
        Task<IList<SaleOffer>> GetOffers();
        
        
        Task<IList<SaleOffer>> GetOfferByUserId(long id);


        Task<SaleOffer> GetOfferBySaleOfferId(long id);
        
        Task AddSaleOffer(SaleOffer saleOffer);

        Task UpdateSaleOfferToFalse(long id);
        
        Task<IList<SaleOfferWallet>> GetItemsById(long id);

        Task DeleteSaleOffer(long id);

        Task<SaleOffer> UpdateSaleOffer(SaleOffer saleOffer);




    }
}