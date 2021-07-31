using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseMaster.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WarehouseMaster.Pages.ProductList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext productDb;

        //ctor tab tab
        public CreateModel(ApplicationDbContext db)
        {
            productDb = db;
        }

        [BindProperty]
        public Product Product { get; set; }

        public void OnGet()
        {

        }

        //TO CHECK VALIDATION ERROR
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                // ADDED TO  QUEUE 
                await productDb.Product.AddAsync(Product);
                //PUSED TO DATABASE
                await productDb.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}