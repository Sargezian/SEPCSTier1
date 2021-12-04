using System.Threading.Tasks;
using SEPCSTier1.Graphql;
using SEPCSTier1.Pages;
using SEPCSTier1.Models;
using Wallet = SEPCSTier1.Models.Wallet;

namespace SEPCSTier1.Data
{
    public class WalletData : IWalletData
    {
        private GraphqlClient graphqlClient;

        public WalletData(GraphqlClient graphqlClient)
        {
            this.graphqlClient = graphqlClient;
        }

        public async Task<long> SumOfPrice(long id)
        {
            var result = await graphqlClient.GetSumOfPrice.ExecuteAsync(id);

            return result.Data.SumOfPriceById;
        }


        public async Task<Wallet> AddUser(Wallet wallet)
        {
            var result = await graphqlClient.AddWallet.ExecuteAsync(wallet.price,wallet.payment_id);

            return wallet;
            
            
        }
    }
}