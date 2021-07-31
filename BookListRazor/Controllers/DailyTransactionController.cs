using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseMaster.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

//THIS IS USED TO CONNECT DailyTransaction LIST JS FILE WITH DATA
namespace WarehouseMaster.Controllers
{
    [Route("api/dailytransaction")]      // navigating to url class ??
    [ApiController]
    public class DailyTransactionController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ApplicationDbContext dTranDb;

        public DailyTransactionController(ApplicationDbContext db)
        {
            dTranDb = db;
        }

        //WHEN A USER CLICKS ON GET DATA
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await dTranDb.DailyTransaction.ToListAsync() });
        }

        //WHEN A USER CLICKS ON DELETE
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var DailyTransactionFromDb = await dTranDb.DailyTransaction.FirstOrDefaultAsync(u => u.TransactionId == id);
            if (DailyTransactionFromDb == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            dTranDb.DailyTransaction.Remove(DailyTransactionFromDb);
            await dTranDb.SaveChangesAsync();
            return Json(new { success = true, message = "Delete successful" });
        }
    }
}