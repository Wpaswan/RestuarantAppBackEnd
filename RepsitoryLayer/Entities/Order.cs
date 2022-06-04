using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantApp.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int OrderId { get; set; }
        public int OrderNumber { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public string PMethod { get; set; }
        public int  GTotal { get; set; }
    }
}
