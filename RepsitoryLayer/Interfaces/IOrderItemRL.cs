using CommonLayer.Models;
using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepsitoryLayer.Interfaces
{
    public interface IOrderItemRL
    {
        Task AddOrder(int customerId,int itemId,OrderItemPostModel orderItemPostModel);
        Task<List<OrderItems>> GetOrder(int userId);
        public bool DeleteOrder(int OrderId);
    }
}
