using BusinessLayer.Interfaces;
using BusinessLayer.Services;
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
    public class AddressController : ControllerBase
    {
        IAddrssBL addressBL;
        RestaurentDBContext restaurentDBContext;
        public AddressController(IAddrssBL addrssBL,RestaurentDBContext restaurentDBContext)
        {

            this.addressBL = addrssBL;
            this.restaurentDBContext = restaurentDBContext;
        }
        [Authorize]
        [HttpPost("AddAddress")]
        public async Task<IActionResult> addAddress(AddressPostModel Model)
        {
            try
            {

                var customerId = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("CustomerID", StringComparison.InvariantCultureIgnoreCase));
                int CustomerId = Int32.Parse(customerId.Value);



                await addressBL.AddAddress( Model, CustomerId);

                return this.Ok(new { success = true, message = "Address added successfully", response = Model });

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
