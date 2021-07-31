using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseMaster.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

//WE ARE RETRIVING ALL OF THE VendorS FROM DATABSE HERE *************
namespace WarehouseMaster.Pages.VendorList
{
    public class IndexModel : PageModel
    {
        //extracting data using dependency injection
        // if you do not use dependency injection then you would need to create and object to retrive and then throw it 
        private readonly ApplicationDbContext vendorDb;

        //getting data for using dependency injection
        public IndexModel(ApplicationDbContext db)
        {
            vendorDb = db;
        }

        public IEnumerable<Vendor> Vendors { get; set; }

        public async Task OnGet()
        {
            // assysn lets to run multiple task at a time until its awaited     
            Vendors = await vendorDb.Vendor.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var ven = await vendorDb.Vendor.FindAsync(id);
            if (ven == null)
            {
                return NotFound();
            }
            vendorDb.Vendor.Remove(ven);
            await vendorDb.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}

