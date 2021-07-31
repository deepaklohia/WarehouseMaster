using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseMaster.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WarehouseMaster.Pages.CustomerList
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext customerDb;

        public EditModel(ApplicationDbContext db)
        {
            customerDb = db;
        }

        [BindProperty]
        public Customer Customer { get; set; }

        public async Task OnGet(int id)
        {
            Customer = await customerDb.Customer.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var BookFromDb = await customerDb.Customer.FindAsync(Customer.customerId);
                BookFromDb.customerId = Customer.customerId;
                BookFromDb.customerName = Customer.customerName;
                BookFromDb.customerAddress = Customer.customerAddress;
                BookFromDb.customerPhone = Customer.customerPhone;
                BookFromDb.customerEmail = Customer.customerEmail;

                await customerDb.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}

