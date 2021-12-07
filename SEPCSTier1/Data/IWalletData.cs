using System.Threading.Tasks;
using SEPCSTier1.Models;

namespace SEPCSTier1.Data
{
    public interface IWalletData
    {
        
        
        Task<long> SumOfBalance(long id);
        Task<Wallet> UpdateWallets(Wallet wallet);

        Task<Wallet> AddWallet(Wallet wallet);

    }
}