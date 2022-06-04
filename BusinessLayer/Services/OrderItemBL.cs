using BusinessLayer.Interfaces;
using CommonLayer.Models;
using RepsitoryLayer.Interfaces;
using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class OrderItemBL : IOrderItemBL
    {
        IOrderItemRL orderItemRL;
        public OrderItemBL(IOrderItemRL orderItemRL)
        {
            this.orderItemRL = orderItemRL;
        }
        public async Task AddOrder(int customerId, int itemId,OrderItemPostModel orderItemPostModel)
        {
            try
            {
              await  orderItemRL.AddOrder(customerId, itemId,orderItemPostModel);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteOrder(int OrderId)
        {
            try
            {
                if (orderItemRL.DeleteOrder(OrderId))
                    return true;
                else
                    return false;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<OrderItems>> GetOrder(int userId)
        {
            try
            {
                return await orderItemRL.GetOrder(userId);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
