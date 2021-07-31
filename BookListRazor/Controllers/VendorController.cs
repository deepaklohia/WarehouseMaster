using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseMaster.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

//THIS IS USED TO CONNECT Vendor LIST JS FILE WITH DATA
namespace WarehouseMaster.Controllers
{
    [Route("api/vendor")]      // navigating to url class ??
    [ApiController]
    public class VendorController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ApplicationDbContext vendorDb;

        public VendorController(ApplicationDbContext db)
        {
            vendorDb = db;
        }

        //WHEN A USER CLICKS ON GET DATA
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await vendorDb.Vendor.ToListAsync() });
        }

        //WHEN A USER CLICKS ON DELETE
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var VendorFromDb = await vendorDb.Vendor.FirstOrDefaultAsync(u => u.vendorId == id);
            if (VendorFromDb == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            vendorDb.Vendor.Remove(VendorFromDb);
            await vendorDb.SaveChangesAsync();
            return Json(new { success = true, message = "Delete successful" });
        }
    }
}