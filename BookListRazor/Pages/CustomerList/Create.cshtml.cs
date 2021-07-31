using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseMaster.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WarehouseMaster.Pages.CustomerList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext customerDb;

        //ctor tab tab
        public CreateModel(ApplicationDbContext db)
        {
            customerDb = db;
        }

        [BindProperty]
        public Customer Customer { get; set; }

        public void OnGet()
        {

        }

        //TO CHECK VALIDATION ERROR
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                // ADDED TO  QUEUE 
                await customerDb.Customer.AddAsync(Customer);
                //PUSED TO DATABASE
                await customerDb.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}

