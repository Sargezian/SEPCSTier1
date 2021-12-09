using System.Collections.Generic;
using System.Threading.Tasks;
using SEPCSTier1.Models;

namespace SEPCSTier1.Data
{
    public interface IOfferData
    {
        Task<IList<SaleOffer>> GetOffers();
        
        
        Task<IList<SaleOffer>> GetOfferByUserId(long id);


        Task<SaleOffer> GetOfferBySaleOfferId(long id);
        
        Task AddSaleOffer(SaleOffer saleOffer);
        
        
        
        
    }
}