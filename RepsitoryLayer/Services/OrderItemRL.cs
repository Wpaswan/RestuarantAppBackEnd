using CommonLayer.Models;
using Microsoft.EntityFrameworkCore;
using RepsitoryLayer.Interfaces;
using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepsitoryLayer.Services
{
    public class OrderItemRL : IOrderItemRL
    {
        private readonly RestaurentDBContext restaurentDBContext;
        public OrderItemRL(RestaurentDBContext restaurentDBContext)
        {
            this.restaurentDBContext = restaurentDBContext;
        }
        public async Task AddOrder(int customerId,int itemId, OrderItemPostModel orderItemPostModel)
        {
            try
            {
                var customer = restaurentDBContext.Customers.FirstOrDefault(x => x.CustomerID == customerId);
                var item=restaurentDBContext.Items.FirstOrDefault(x =>x.ItemId == itemId);
                OrderItems order1 = new OrderItems();
                order1.CustomerID=customerId;
                order1.ItemId=itemId;
                order1.OrderItemId =new OrderItems().OrderItemId;
                order1.Quantity = orderItemPostModel.Quantity;
                order1.PMethod = orderItemPostModel.PMethod;
                
                restaurentDBContext.OrderItems.Add(order1);
                await restaurentDBContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteOrder(int OrderId)
        {
            OrderItems orderItems = restaurentDBContext.OrderItems.Where(l => l.OrderItemId==OrderId).FirstOrDefault();
            if (orderItems!=null)
            {
                restaurentDBContext.OrderItems.Remove(orderItems);
                restaurentDBContext.SaveChanges();
                return true;
            }
            else
            {
                return false;   
            }

        }

        public async Task<List<OrderItems>> GetOrder(int userId)
        {
            return await restaurentDBContext.OrderItems.Where(l => l.CustomerID==userId)
                .Include(u => u.Item)
                .ToListAsync();


           
        }
    }
}
