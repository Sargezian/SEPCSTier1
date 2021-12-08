using System.Collections.Generic;
using System.Threading.Tasks;
using SEPCSTier1.Models;

namespace SEPCSTier1.Data
{
    public interface ISoldOfferData
    {
        Task<IList<SoldOffer>> GetSoldOffers();
        Task<SoldOffer> GetSoldOfferById(long id);
        void AddSoldOffer(SoldOffer soldOffer);
    }
}