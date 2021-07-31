using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

//this is created to create SQL DB
namespace WarehouseMaster.Model
{
    public class DailyTransaction
    {
        [Key]
        public int TransactionId { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }

        [Required]
        public String TransactionName { get; set; }

        [Required]
        public String TransactionDetails { get; set; }

        public Decimal TransactionInAmt { get; set; }

        [Required]
        public Decimal TransactionOutAmt { get; set; }

        [Required]
        public Decimal TransactionBalance { get; set; }

    }
}
