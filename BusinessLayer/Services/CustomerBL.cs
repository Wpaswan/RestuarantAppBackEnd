using BusinessLayer.Interfaces;
using CommonLayer.Models;
using RepositoryLayer.Interfaces;
using RepsitoryLayer.Services;
using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class CustomerBL:ICustomerBL
    {
        ICustomerRL ICustomerRL;
        public CustomerBL(ICustomerRL ICustomerRL)
        {
            this.ICustomerRL = ICustomerRL;

        }

        public List<Customer> GetAll()
        {
            try
            {
                return this.ICustomerRL.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string login(Login userLogin)
        {
            try
            {
               return ICustomerRL.login(userLogin);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void RegisterCustomer(CustomerPostModel customer)
        {
            try
            {
                 ICustomerRL.RegisterCustomer(customer);

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
