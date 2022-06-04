using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantApp.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int CustomerID { get; set; }
        [Required]
        public string CustomerName { get; set; }
        public string email { get; set; }
        [Required]

        public string password { get; set; }
        public string cPassword { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
