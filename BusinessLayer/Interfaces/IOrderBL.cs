using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IOrderBL
    {
        Task AddOrder(int customerId, OrderPostModel orderPostModel);
    }
}
