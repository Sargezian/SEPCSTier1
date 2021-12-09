using System.Collections.Generic;
using System.Threading.Tasks;
using SEPCSTier1.Models;

namespace SEPCSTier1.Data
{
    public interface ISoldOfferData
    {
        Task<IList<SoldOffer>> GetSoldOffers();
        
        Task<IList<SoldOffer>> getSoldOfferByOrderId(long id);
        
        Task<IList<SoldOffer>> getSoldOfferBySellerWalletId(long id);
        Task<SoldOffer> GetSoldOfferById(long id);
        Task<SoldOffer> AddSoldOffer(SoldOffer soldOffer);
    }
}