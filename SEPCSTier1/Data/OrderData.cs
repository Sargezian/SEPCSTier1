using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEPCSTier1.Graphql;
using SEPCSTier1.Pages;
using SEPCSTier1.Models;
using StrawberryShake;
using Wallet = SEPCSTier1.Models.Wallet;

namespace SEPCSTier1.Data
{
    public class OrderData : IOrderData
    {
        private GraphqlClient graphqlClient;
        private List<Order> OrderList = new List<Order>();
        private IList<OrderByBuyer> orderByBuyersList = new List<OrderByBuyer>();

        public OrderData(GraphqlClient graphqlClient)
        {
            this.graphqlClient = graphqlClient;
        }


        public async Task<IList<Order>> GetOrder()
        {
            var result = await graphqlClient.GetOrder.ExecuteAsync();

            
            OrderList = result.Data.Order.Select(offer => new Order()
            {
                id = offer.Id,
                wallet_buyer_id = offer.Wallet_buyer_id,
                sale_id = offer.Sale_id
            }).ToList();
            
            return OrderList;
        }
        
        public async Task<IList<Order>> getOrderByWalletBuyerId(long id)
        {
            var result = await graphqlClient.OrderByWalletId.ExecuteAsync(id);

            
            OrderList = result.Data.GetOrderByWalletBuyerId.Select(offer => new Order()
            {
                id = offer.Id,
                wallet_buyer_id = offer.Wallet_buyer_id,
                sale_id = offer.Sale_id
            }).ToList();
            
            return OrderList;
        }
        
        
        
        

        public async Task<Order> GetOrderByID(long id)
        {
            var result = await graphqlClient.GetOrderById.ExecuteAsync(id);
           

            Order itemss = new Order()
            {
                id = result.Data.OrderById.Id,
                wallet_buyer_id = result.Data.OrderById.Wallet_buyer_id,
                sale_id = result.Data.OrderById.Sale_id
            };
            
            return itemss;
        }
        
        public async Task<Order> GetOrderBySaleId(long id)
        {
            var result = await graphqlClient.GetOrderBySaleId.ExecuteAsync(id);
           

            Order itemss = new Order()
            {
                id = result.Data.OrderBySaleId.Id,
                wallet_buyer_id = result.Data.OrderBySaleId.Wallet_buyer_id,
                sale_id = result.Data.OrderBySaleId.Sale_id
            };
            
            return itemss;
        }
        public async Task<Order> AddOrder(Order order)
        {
            await graphqlClient.AddOrder.ExecuteAsync(order.wallet_buyer_id, order.sale_id);

            return order;
        }

        public async Task<IList<OrderByBuyer>> GetBoughtItems(long id)
        {
            var result = await graphqlClient.GetBoughtItems.ExecuteAsync(id);

            orderByBuyersList = result.Data.BoughtItems.Select(item => new OrderByBuyer()
            {
                order_id= item.Order_id,
                weaponname = item.Weaponname,
                weaponURL = item.WeaponURL,
                sale_price = item.Sale_price
                
                
            }).ToList();


            return orderByBuyersList;
        }
    }
}