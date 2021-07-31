using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseMaster.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WarehouseMaster.Pages.VendorList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext vendorDb;

        //ctor tab tab
        public CreateModel(ApplicationDbContext db)
        {
            vendorDb = db;
        }

        [BindProperty]
        public Vendor Vendor { get; set; }

        public void OnGet()
        {

        }

        //TO CHECK VALIDATION ERROR
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                // ADDED TO  QUEUE 
                await vendorDb.Vendor.AddAsync(Vendor);
                //PUSED TO DATABASE
                await vendorDb.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}

