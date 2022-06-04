using BusinessLayer.Interfaces;
using CommonLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepsitoryLayer.Services;
using RestaurantApp.Models;
using System;
using System.Threading.Tasks;

namespace RestaurantApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly RestaurentDBContext restaurentDBContext;
        ICustomerBL customerBL;
        public CustomerController(ICustomerBL customerBL,RestaurentDBContext restaurentDBContext)
        {
            this.customerBL = customerBL;
            this.restaurentDBContext = restaurentDBContext;
        }
        [HttpPost("AddCustomers")]
        public ActionResult  AddCustomers(CustomerPostModel customer)
        {
            try
            {
                this.customerBL.RegisterCustomer(customer);
                return this.Ok(new { success = true, message = $"Registration Successful for   {customer.CustomerName}" });
                return BadRequest();
            }
            catch(Exception ex)
            {
                throw ex;

            }

            
        }
        [HttpPost("login")]
        public ActionResult Login(Login login)
        {
            try
            {
                string result = this.customerBL.login(login);
                if (result != null)
                    //return this.Ok(new { success = true, message = $"LogIn Successful  {login.email},token = {result}" });
                    return this.Ok(new { Success = true, message = "Login Successful", token = $"{result}"  });
                else
                    return this.BadRequest(new { Success = false, message = "Invalid Username and Password" });
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpGet("getall")]
        public ActionResult GetAll()
        {
            try
            {
                var result = this.customerBL.GetAll();
                return this.Ok(new { success = true, message = $"Below are the User data", data = result });
            }
            catch (Exception e)
            {
                throw e;
            }


        }
    }
}
