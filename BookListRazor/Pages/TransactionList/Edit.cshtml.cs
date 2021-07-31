using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseMaster.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WarehouseMaster.Pages.TransactionList
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext tranDb;

        public EditModel(ApplicationDbContext db)
        {
            tranDb = db;
        }

        [BindProperty]
        public Transaction Transaction { get; set; }

        public async Task OnGet(int id)
        {
            Transaction = await tranDb.Transaction.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var BookFromDb = await tranDb.Transaction.FindAsync(Transaction.TransactionId);
                BookFromDb.TransactionDate = Transaction.TransactionDate;
                BookFromDb.TransactionName = Transaction.TransactionName;
                BookFromDb.TransactionDesc = Transaction.TransactionDesc;
                BookFromDb.TransactionInvoiceRef = Transaction.TransactionInvoiceRef;
                BookFromDb.ProductId = Transaction.ProductId;
                BookFromDb.ProductName = Transaction.ProductName;
                BookFromDb.InventoryInUnit = Transaction.InventoryInUnit;
                BookFromDb.InventoryOutUnit = Transaction.InventoryOutUnit;
                BookFromDb.InventoryBalUnit = Transaction.InventoryBalUnit;
                BookFromDb.ProductCostPricePU = Transaction.ProductCostPricePU;
                BookFromDb.ProductSellingPricePU = Transaction.ProductSellingPricePU;
                BookFromDb.InvBalCostPriceTotal = Transaction.InvBalCostPriceTotal;

                await tranDb.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}

