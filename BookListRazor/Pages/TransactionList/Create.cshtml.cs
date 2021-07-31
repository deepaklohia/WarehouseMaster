using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseMaster.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WarehouseMaster.Pages.TransactionList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext tranDb;

        //ctor tab tab
        public CreateModel(ApplicationDbContext db)
        {
            tranDb = db;
        }

        [BindProperty]
        public Transaction Transaction { get; set; }

        public void OnGet()
        {

        }

        //TO CHECK VALIDATION ERROR
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                // ADDED TO  QUEUE 
                await tranDb.Transaction.AddAsync(Transaction);
                //PUSED TO DATABASE
                await tranDb.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}

