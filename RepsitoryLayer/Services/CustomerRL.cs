
using CommonLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Interfaces;
using RepsitoryLayer.Services;
using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace RepositoryLayer.Services
{
    
    public class CustomerRL:ICustomerRL
    {
        private readonly RestaurentDBContext restaurentDBContext;
       
        public CustomerRL(RestaurentDBContext restaurentDBContext)
        {
            this.restaurentDBContext = restaurentDBContext;
        }

        public  List<Customer> GetAll()
        {
            
                try
                {
                var result = restaurentDBContext.Customers.ToList();
                return  result;
                }
                catch (Exception e)
                {
                    throw e;
                }
            
        }

        public void RegisterCustomer(CustomerPostModel customer)
        {
            Customer customer1 = new Customer();
            customer1.CustomerID = new Customer().CustomerID;
            customer1.CustomerName = customer.CustomerName;
            customer1.email=customer.email;
            customer1.password=customer.password;
            customer1.cPassword=customer.cPassword; ;
            
            restaurentDBContext.Customers.Add(customer1);
            restaurentDBContext.SaveChanges();

        }
        private static string GenerateToken(string email)
        {
            if (email == null)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes("THIS_IS_MY_KEY_TO_GENERATE_TOKEN");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("email", email),
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials =
                new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private static string GenerateJWTToken(string email, int CustomerID)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes("THIS_IS_MY_KEY_TO_GENERATE_TOKEN");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("email", email),
                    new Claim("CustomerID", CustomerID.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials =
                new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string login(Login userLogin)
        {
            try
            {
                Customer customer = new Customer();

                var result = restaurentDBContext.Customers.Where(x => x.email == userLogin.email && x.password == userLogin.Password).FirstOrDefault();
                int Id = result.CustomerID;
                if (result != null)
                {
                    return GenerateJWTToken(userLogin.email, Id);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
