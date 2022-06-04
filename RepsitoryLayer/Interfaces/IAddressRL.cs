using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepsitoryLayer.Interfaces
{
    public interface IAddressRL
    {
        Task AddAddress(AddressPostModel addressPostModel,int CustomerId);
    }
}
