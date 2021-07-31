using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

//this is created to create SQL DB
namespace WarehouseMaster.Model
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }

        [Required]
        public String TransactionName { get; set; }

        [Required]
        public String TransactionDesc { get; set; }

        public String TransactionInvoiceRef { get; set; }

        [Required]
        public int ProductId { get; set; }

        public String ProductName { get; set; }

        [Required]
        public int InventoryInUnit { get; set; }

        [Required]
        public int InventoryOutUnit { get; set; }

        [Required]
        public int InventoryBalUnit { get; set; }

        public Double ProductCostPricePU { get; set; }

        public Double ProductSellingPricePU { get; set; }

        public Double InvBalCostPriceTotal { get; set; }
    }
}
