using CommonLayer.Models;
using RepsitoryLayer.Services;
using RestaurantApp.Models;
using System.Collections.Generic;

namespace BusinessLayer.Interfaces
{
    public interface ICustomerBL
    {
        void RegisterCustomer(CustomerPostModel customer);
        public string login(Login userLogin);
        List<Customer> GetAll();
    }
}
