using BusinessLayer.Interfaces;
using CommonLayer.Models;
using RepsitoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class AddressBL : IAddrssBL
    {
        IAddressRL addressRL;
        public AddressBL(IAddressRL addressRL)
        {
            this.addressRL = addressRL;
        }
        public async Task AddAddress(AddressPostModel addressPostModel, int CustomerId)
        {
            try
            {
                await this.addressRL.AddAddress(addressPostModel, CustomerId);

            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
    }
}
