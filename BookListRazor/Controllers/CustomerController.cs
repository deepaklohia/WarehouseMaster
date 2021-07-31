using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseMaster.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

//THIS IS USED TO CONNECT Customer LIST JS FILE WITH DATA
namespace WarehouseMaster.Controllers
{
    [Route("api/customer")]      // navigating to url class ??
    [ApiController]
    public class CustomerController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ApplicationDbContext customerDb;

        public CustomerController(ApplicationDbContext db)
        {
            customerDb = db;
        }

        //WHEN A USER CLICKS ON GET DATA
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await customerDb.Customer.ToListAsync() });
        }

        //WHEN A USER CLICKS ON DELETE
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var CustomerFromDb = await customerDb.Customer.FirstOrDefaultAsync(u => u.customerId == id);
            if (CustomerFromDb == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            customerDb.Customer.Remove(CustomerFromDb);
            await customerDb.SaveChangesAsync();
            return Json(new { success = true, message = "Delete successful" });
        }
    }
}
