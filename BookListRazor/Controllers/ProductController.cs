using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseMaster.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

//THIS IS USED TO CONNECT PRODUCT LIST JS FILE WITH DATA
namespace WarehouseMaster.Controllers
{
    [Route("api/product")]      // navigating to url class ??
    [ApiController]
    public class ProductController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ApplicationDbContext productDb;

        public ProductController(ApplicationDbContext db)
        {
            productDb = db;
        }

        //WHEN A USER CLICKS ON GET DATA
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await productDb.Product.ToListAsync() });
        }

        //WHEN A USER CLICKS ON DELETE
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var productFromDb = await productDb.Product.FirstOrDefaultAsync(u => u.productId == id);
            if (productFromDb == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            productDb.Product.Remove(productFromDb);
            await productDb.SaveChangesAsync();
            return Json(new { success = true, message = "Delete successful" });
        }
    }
}