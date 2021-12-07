using System.Threading.Tasks;
using SEPCSTier1.Models;

namespace SEPCSTier1.Data
{
    public interface IWalletData
    {
        
        
        Task<long> SumOfPrice(long id);
        Task<Wallet> UpdateWallet(Wallet wallet);

        Task<Wallet> AddWallet(Wallet wallet);

    }
}