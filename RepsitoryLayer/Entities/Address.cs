using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepositoryLayer.Entity
{
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int AddressId { get; set; }
       
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public string colony { get; set; }
        public string QuarterNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        
    }
}
