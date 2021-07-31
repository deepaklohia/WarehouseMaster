using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseMaster.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

//WE ARE RETRIVING ALL OF THE CustomerS FROM DATABSE HERE *************
namespace WarehouseMaster.Pages.CustomerList
{
    public class IndexModel : PageModel
    {
        //extracting data using dependency injection
        // if you do not use dependency injection then you would need to create and object to retrive and then throw it 
        private readonly ApplicationDbContext customerDb;

        //getting data for using dependency injection
        public IndexModel(ApplicationDbContext db)
        {
            customerDb = db;
        }

        public IEnumerable<Customer> Customers { get; set; }

        public async Task OnGet()
        {
            // assysn lets to run multiple task at a time until its awaited     
            Customers = await customerDb.Customer.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var cust = await customerDb.Customer.FindAsync(id);
            if (cust == null)
            {
                return NotFound();
            }
            customerDb.Customer.Remove(cust);
            await customerDb.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}

