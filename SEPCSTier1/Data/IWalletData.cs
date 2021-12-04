using System.Threading.Tasks;

namespace SEPCSTier1.Data
{
    public interface IWalletData
    {
        
        
        Task<long> SumOfPrice(long id);
        
    }
}