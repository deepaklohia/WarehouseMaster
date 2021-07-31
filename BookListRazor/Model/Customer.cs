using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

//this is created to create SQL DB
namespace WarehouseMaster.Model
{
    public class Customer
    {
        [Key]
        public int customerId { get; set; }

        [Required]
        public String customerName { get; set; }

        [Required]
        public String customerAddress { get; set; }

        [Required]
        public String customerPhone { get; set; }

        [Required]
        public String customerEmail { get; set; }

    }
}
