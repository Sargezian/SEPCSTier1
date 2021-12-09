using System.Collections.Generic;
using System.Threading.Tasks;
using SEPCSTier1.Models;

namespace SEPCSTier1.Data
{
    public interface IOrderData
    {
        
        Task<IList<Order>> GetOrder();
        Task<Order> GetOrderByID(long id);
        Task<Order> GetOrderBySaleId(long id);
        Task<Order> AddOrder(Order order);

    }
}