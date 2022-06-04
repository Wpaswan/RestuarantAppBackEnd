using BusinessLayer.Interfaces;
using CommonLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        RestaurentDBContext restaurentDBContext;
        IItemBL itemBL;
        public ItemController(RestaurentDBContext restaurentDBContext,IItemBL itemBL)
        {
            this.restaurentDBContext = restaurentDBContext; 
            this.itemBL = itemBL;
        }
        [HttpPost("addItems")]
        public async Task<IActionResult> AddNote(ItemPostModel ItemsPost)
        {
            try
            {
               

                await this.itemBL.AddItem(ItemsPost);


                return this.Ok(new { success = true, Message = $"Items added is successfull {ItemsPost}" });
                return this.BadRequest(new {success=false,Message="Something went wrong"});
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpGet("getAllItems")]
        public async Task<IActionResult> GetAllNotes()
        {
            try
            {
               
                var noteList = new List<Item>();
                noteList = await itemBL.GetAllItems();

                return this.Ok(new { Success = true, message = $"GetAll Items successfull ", data = noteList });

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
