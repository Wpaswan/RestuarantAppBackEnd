using BusinessLayer.Interfaces;
using CommonLayer.Models;
using RepsitoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class OrderBL : IOrderBL
    {
        IOrderRL IorderRL;
        public OrderBL(IOrderRL IorderRL)
        {
            this.IorderRL = IorderRL;
        }
        public async Task AddOrder(int customerId, OrderPostModel orderPostModel)
        {
            try
            {
                 await  this.IorderRL.AddOrder(customerId, orderPostModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
