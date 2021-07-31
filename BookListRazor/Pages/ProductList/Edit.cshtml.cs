using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseMaster.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WarehouseMaster.Pages.ProductList
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext productDb;

        public EditModel(ApplicationDbContext db)
        {
            productDb = db;
        }

        [BindProperty]
        public Product Product { get; set; }

        public async Task OnGet(int id)
        {
            Product = await productDb.Product.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var BookFromDb = await productDb.Product.FindAsync(Product.productId);
                BookFromDb.productId = Product.productId;
                BookFromDb.productName = Product.productName;
                BookFromDb.productDesc = Product.productDesc;
                BookFromDb.vendorId = Product.vendorId;
                BookFromDb.vendorName = Product.vendorName;
                BookFromDb.productCost = Product.productCost;
                BookFromDb.productMargin = Product.productMargin;
                BookFromDb.productSellingPrice = Product.productSellingPrice;

                await productDb.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}