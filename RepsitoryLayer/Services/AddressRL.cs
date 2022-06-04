using CommonLayer.Models;
using RepositoryLayer.Entity;
using RepsitoryLayer.Interfaces;
using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepsitoryLayer.Services
{
    public class AddressRL:IAddressRL
    {
        private readonly RestaurentDBContext restaurentDBContext;
        public AddressRL(RestaurentDBContext restaurentDBContext)
        {
            this.restaurentDBContext = restaurentDBContext;
        }

        public async Task AddAddress(AddressPostModel addressPostModel,int customerId)
        {
            try
            {
                var customer = restaurentDBContext.Customers.FirstOrDefault(x => x.CustomerID == customerId);

                Address address=new Address();
                address.CustomerId = customerId;
                address.AddressId=new Address().AddressId;
                address.QuarterNumber = addressPostModel.QuarterNumber;
                address.colony=addressPostModel.colony;
                address.City=addressPostModel.City;
                address.State=addressPostModel.State;
                restaurentDBContext.Addresses.Add(address);
                await restaurentDBContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
