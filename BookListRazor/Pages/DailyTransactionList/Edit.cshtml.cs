using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseMaster.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WarehouseMaster.Pages.DailyTransactionList
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext dTranDb;

        public EditModel(ApplicationDbContext db)
        {
            dTranDb = db;
        }

        [BindProperty]
        public DailyTransaction DailyTransaction { get; set; }

        public async Task OnGet(int id)
        {
            DailyTransaction = await dTranDb.DailyTransaction.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var BookFromDb = await dTranDb.DailyTransaction.FindAsync(DailyTransaction.TransactionId);
                BookFromDb.TransactionDate = DailyTransaction.TransactionDate;
                BookFromDb.TransactionName = DailyTransaction.TransactionName;
                BookFromDb.TransactionDetails = DailyTransaction.TransactionDetails;
                BookFromDb.TransactionInAmt = DailyTransaction.TransactionInAmt;
                BookFromDb.TransactionOutAmt = DailyTransaction.TransactionOutAmt;
                BookFromDb.TransactionBalance = DailyTransaction.TransactionBalance;
                
                await dTranDb.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}

