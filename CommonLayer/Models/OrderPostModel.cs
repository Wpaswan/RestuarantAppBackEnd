using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Models
{
    public class OrderPostModel
    {
        public int OrderNumber { get; set; }
        public string PMethod { get; set; }
        public int GTotal { get; set; }
    }
}
