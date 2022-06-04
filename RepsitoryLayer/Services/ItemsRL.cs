using CommonLayer.Models;
using Microsoft.EntityFrameworkCore;
using RepsitoryLayer.Interfaces;
using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RepsitoryLayer.Services
{
    public class ItemsRL : IItems
    {
        private readonly RestaurentDBContext restaurentDBContext;
        
        public ItemsRL(RestaurentDBContext restaurentDBContext)
        {
            this.restaurentDBContext = restaurentDBContext;
        }
        public async Task AddItem( ItemPostModel items)
        {
            try
            {
                


                Item item = new Item();
                item.ItemId=new Item().ItemId;
                item.ItemName=items.ItemName;
                item.ItemPrice=items.ItemPrice;
                item.Image=items.Image;
                restaurentDBContext.Items.Add(item);
                await restaurentDBContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        

        public async Task<List<Item>> GetAllItems()
        {
            return await restaurentDBContext.Items

              
              .ToListAsync();
        }

       
    }
}
