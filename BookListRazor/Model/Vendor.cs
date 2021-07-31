using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

//this is created to create SQL DB
namespace WarehouseMaster.Model
{
    public class Vendor
    {
        [Key]
        public int vendorId { get; set; }

        [Required]
        public String vendorName { get; set; }

        [Required]
        public String vendorAddress { get; set; }

        [Required]
        public String vendorPhone { get; set; }

        [Required]
        public String vendorEmail { get; set; }

    }
}
