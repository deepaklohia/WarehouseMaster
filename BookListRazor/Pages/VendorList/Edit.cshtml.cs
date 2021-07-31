using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseMaster.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WarehouseMaster.Pages.VendorList
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext vendorDb;

        public EditModel(ApplicationDbContext db)
        {
            vendorDb = db;
        }

        [BindProperty]
        public Vendor Vendor { get; set; }

        public async Task OnGet(int id)
        {
            Vendor = await vendorDb.Vendor.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var BookFromDb = await vendorDb.Vendor.FindAsync(Vendor.vendorId);
                BookFromDb.vendorId = Vendor.vendorId;
                BookFromDb.vendorName = Vendor.vendorName;
                BookFromDb.vendorAddress = Vendor.vendorAddress;
                BookFromDb.vendorPhone = Vendor.vendorPhone;
                BookFromDb.vendorEmail = Vendor.vendorEmail;
                
                await vendorDb.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}

