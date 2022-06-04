using CommonLayer.Models;
using RepsitoryLayer.Interfaces;
using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepsitoryLayer.Services
{
    public class OrderRL : IOrderRL
    {
        private readonly RestaurentDBContext restaurentDBContext;
        public OrderRL(RestaurentDBContext restaurentDBContext)
        {
            this.restaurentDBContext = restaurentDBContext;
        }

        public async Task AddOrder(int customerId, OrderPostModel orderPostModel)
        {
            try
            {
                var customer = restaurentDBContext.Customers.FirstOrDefault(x => x.CustomerID == customerId);

                Order order1 = new Order();
                order1.CustomerId=customerId;
                order1.OrderId =new Order().OrderId;
                order1.OrderNumber = orderPostModel.OrderNumber;
                order1.PMethod = orderPostModel.PMethod;
                order1.GTotal = orderPostModel.GTotal;
                restaurentDBContext.Orders.Add(order1);
                await restaurentDBContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
