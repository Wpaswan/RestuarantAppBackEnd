using BusinessLayer.Interfaces;
using CommonLayer.Models;
using RepsitoryLayer.Interfaces;
using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class ItemBL : IItemBL
    {
        IItems Items;
        public ItemBL(IItems Items)
            {
            this.Items = Items;
            }
        public async Task AddItem(ItemPostModel items)
        {
            try
            {
                 await this.Items.AddItem(items);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Item>> GetAllItems()
        {
            try
            {
               return await this.Items.GetAllItems();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
