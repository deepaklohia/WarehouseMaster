using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseMaster.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WarehouseMaster.Pages.DailyTransactionList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext dTranDb;

        //ctor tab tab
        public CreateModel(ApplicationDbContext db)
        {
            dTranDb = db;
        }

        [BindProperty]
        public DailyTransaction DailyTransaction { get; set; }

        public void OnGet()
        {

        }

        //TO CHECK VALIDATION ERROR
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                // ADDED TO  QUEUE 
                await dTranDb.DailyTransaction.AddAsync(DailyTransaction);
                //PUSED TO DATABASE
                await dTranDb.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}

