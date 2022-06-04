using BusinessLayer.Interfaces;
using CommonLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantApp.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        RestaurentDBContext restaurentDBContext;
        IOrderBL orderBL;
        public OrderController(RestaurentDBContext restaurentDBContext,IOrderBL orderBL)
        {
            this.restaurentDBContext = restaurentDBContext;
                this.orderBL = orderBL;
        }
       [Authorize]
        [HttpPost("addOrders")]
        public async Task<IActionResult> AddOrder(OrderPostModel orderPostModel)
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("CustomerID", StringComparison.InvariantCultureIgnoreCase));
                int UserId = Int32.Parse(userId.Value);

                await this.orderBL.AddOrder( UserId,orderPostModel);


                return this.Ok(new { success = true, Message = $"Registration is successfull" });
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
