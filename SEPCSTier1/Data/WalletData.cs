﻿using System;
using System.Threading.Tasks;
using SEPCSTier1.Graphql;
using SEPCSTier1.Pages;
using SEPCSTier1.Models;
using StrawberryShake;
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

        public async Task<Wallet> UpdateWallets(Wallet wallet)
        {
            var result = await graphqlClient.UpdateWallet.ExecuteAsync(wallet.user_id, wallet.balance);

            var wallets = new Wallet
            {
                id = result.Data.UpdatePrice.Id,
                user_id = result.Data.UpdatePrice.User_id,
                balance = result.Data.UpdatePrice.Balance,
                
            };

            return wallets;

        }

        public async Task<long> SumOfBalance(long id)
        {
            try
            {

                var result = await graphqlClient.GetSumOfPrice.ExecuteAsync(id);
             if (result.Data == null)
             {
                 throw new Exception("this is an error");
             }
             return result.Data.SumOfPriceById;
             
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
          

           

           
        }


        public async Task<Wallet> AddWallet(Wallet wallet)
        {
            var result = await graphqlClient.AddWallet.ExecuteAsync(wallet.balance,wallet.user_id);

            return wallet;
            
            
        }

        public async Task<Wallet> getWalletById(long id)
        {
            var result = await graphqlClient.GetWalletById.ExecuteAsync(id);
           

             Wallet itemss = new Wallet()
             {
                 id = result.Data.WalletById.Id,
                balance = result.Data.WalletById.Balance,
                 user_id = result.Data.WalletById.User_id,
                 creditcard_id = result.Data.WalletById.Creditcard_id
             };
            
            return itemss;
        }
    }
}