using System.Collections.Generic;
using System.Threading.Tasks;
using SEPCSTier1.Models;

namespace SEPCSTier1.Data
{
    public interface IOfferData
    {
        Task<IList<SaleOffer>> GetOffers();
        Task<SaleOffer> GetOfferById(long id);
        
        void AddSaleOffer(SaleOffer saleOffer);
        
        
        
        
    }
}