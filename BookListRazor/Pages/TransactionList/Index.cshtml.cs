using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseMaster.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

//WE ARE RETRIVING ALL OF THE TransactionS FROM DATABSE HERE *************
namespace WarehouseMaster.Pages.TransactionList
{
    public class IndexModel : PageModel
    {
        //extracting data using dependency injection
        // if you do not use dependency injection then you would need to create and object to retrive and then throw it 
        private readonly ApplicationDbContext tranDb;

        //getting data for using dependency injection
        public IndexModel(ApplicationDbContext db)
        {
            tranDb = db;
        }

        public IEnumerable<Transaction> Transactions { get; set; }

        public async Task OnGet()
        {
            // assysn lets to run multiple task at a time until its awaited     
            Transactions = await tranDb.Transaction.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var tran = await tranDb.Transaction.FindAsync(id);
            if (tran == null)
            {
                return NotFound();
            }
            tranDb.Transaction.Remove(tran);
            await tranDb.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}

