using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseMaster.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

//WE ARE RETRIVING ALL OF THE PRODUCTS FROM DATABSE HERE *************
namespace WarehouseMaster.Pages.ProductList
{
    public class IndexModel : PageModel
    {
        //extracting data using dependency injection
        // if you do not use dependency injection then you would need to create and object to retrive and then throw it 
        private readonly ApplicationDbContext productDb;

        //getting data for using dependency injection
        public IndexModel(ApplicationDbContext db)
        {
            productDb = db;
        }

        public IEnumerable<Product> Products { get; set; }

        public async Task OnGet()
        {
            // assysn lets to run multiple task at a time until its awaited     
            Products = await productDb.Product.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var book = await productDb.Product.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            productDb.Product.Remove(book);
            await productDb.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}