using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantApp.Models
{
    public class Item
    {
        //public Item()
        //{
        //    this.OrderItems = new HashSet<OrderItems>();
        //}
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int ItemId { get; set; }
        [Required]
        public string ItemName { get; set; }
        [Required]
        public int ItemPrice { get; set; }
        public string Image { get; set; }

        //public virtual ICollection<OrderItems> OrderItems { get; set; }
    }
}
