using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IAddrssBL
    {
        Task AddAddress(AddressPostModel addressPostModel, int CustomerId);
    }
}
