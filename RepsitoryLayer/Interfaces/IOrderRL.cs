using CommonLayer.Models;
using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepsitoryLayer.Interfaces
{
    public interface IOrderRL
    {
        Task AddOrder(int customerId, OrderPostModel orderPostModel);
      
    }
}
