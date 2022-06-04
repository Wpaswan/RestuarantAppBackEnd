using BusinessLayer.Interfaces;
using CommonLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        IOrderItemBL OrderItemBL;
        RestaurentDBContext restaurentDBContext;
        public OrderItemController(IOrderItemBL orderItemBL,RestaurentDBContext restaurentDBContext)
        {
            this.restaurentDBContext = restaurentDBContext;
            this.OrderItemBL = orderItemBL;
        }
        [Authorize]
        [HttpPost("AddOrder")]
        public async Task<IActionResult> CreateLabel(OrderItemPostModel Model, int itemId)
        {
            try
            {

                var customerId = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("CustomerID", StringComparison.InvariantCultureIgnoreCase));
                int CustomerId = Int32.Parse(customerId.Value);



                 await OrderItemBL.AddOrder(CustomerId, itemId, Model);

                return this.Ok(new { success = true, message = "order added successfully", response = itemId });

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        [Authorize]
        [HttpGet("getOrders")]
        public async Task<IActionResult> getOrders()
        {
            try
            {
                var customerId = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("CustomerID", StringComparison.InvariantCultureIgnoreCase));
                int CustomerId = Int32.Parse(customerId.Value);
                var orderList = new List<OrderItems>();
               var result=  await OrderItemBL.GetOrder(CustomerId); 

                return this.Ok(new { Success = true, message = $"MyAllOrders successfull ", data = result });

            }
            catch (Exception)
            {

                throw;
            }
        }
        [Authorize]
        [HttpDelete("deleteOrder/{OrderId}")]
        public IActionResult DeleteNote(int OrderId)
        {
            try
            {
                if (OrderItemBL.DeleteOrder(OrderId))
                {
                    return this.Ok(new { Success = true, message = "Order deleted successfully" });

                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "ID not found" });
                }

            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
