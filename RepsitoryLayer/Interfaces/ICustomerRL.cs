using CommonLayer.Models;
using RepsitoryLayer.Services;
using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
    public interface ICustomerRL
    {
           void RegisterCustomer(CustomerPostModel customer);
           public string login(Login userLogin);

           List<Customer> GetAll();

        
    }
}
