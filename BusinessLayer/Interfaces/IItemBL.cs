using CommonLayer.Models;
using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IItemBL
    {
        Task AddItem(ItemPostModel items);

        Task<List<Item>> GetAllItems();

    }
}
