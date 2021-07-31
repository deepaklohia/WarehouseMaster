using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

//this is created to create SQL DB
namespace WarehouseMaster.Model
{
    public class Product
    {
        [Key]
        public int productId { get; set; }

        [Required]
        public String productName { get; set; }

        [Required]
        public String productDesc { get; set; }

        [Required]
        public int vendorId { get; set; }

        public String vendorName { get; set; }

        [Required]
        public String productCost { get; set; }

        [Required]
        public String productMargin { get; set; }

        [Required]
        public String productSellingPrice { get; set; }

    }
}
