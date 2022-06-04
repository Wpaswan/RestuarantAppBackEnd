using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Models
{
    public class CustomerPostModel
    {
       
        public int CustomerID { get; set; }
        
        public string CustomerName { get; set; }
        public string email { get; set; }
        

        public string password { get; set; }
        public string cPassword { get; set; }
    }
}
