using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseMaster.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

//WE ARE RETRIVING ALL OF THE DailyTransactionS FROM DATABSE HERE *************
namespace WarehouseMaster.Pages.DailyTransactionList
{
    public class IndexModel : PageModel
    {
        //extracting data using dependency injection
        // if you do not use dependency injection then you would need to create and object to retrive and then throw it 
        private readonly ApplicationDbContext dTranDb;

        //getting data for using dependency injection
        public IndexModel(ApplicationDbContext db)
        {
            dTranDb = db;
        }

        public IEnumerable<DailyTransaction> DailyTransactions { get; set; }

        public async Task OnGet()
        {
            // assysn lets to run multiple task at a time until its awaited     
            DailyTransactions = await dTranDb.DailyTransaction.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var dTran = await dTranDb.DailyTransaction.FindAsync(id);
            if (dTran == null)
            {
                return NotFound();
            }
            dTranDb.DailyTransaction.Remove(dTran);
            await dTranDb.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}

