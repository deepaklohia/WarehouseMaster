using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseMaster.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

//THIS IS USED TO CONNECT Transaction LIST JS FILE WITH DATA
namespace WarehouseMaster.Controllers
{
    [Route("api/transaction")]      // navigating to url class ??
    [ApiController]
    public class TransactionController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ApplicationDbContext tranDb;

        public TransactionController(ApplicationDbContext db)
        {
            tranDb = db;
        }

        //WHEN A USER CLICKS ON GET DATA
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await tranDb.Transaction.ToListAsync() });
        }

        //WHEN A USER CLICKS ON DELETE
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var TransactionFromDb = await tranDb.Transaction.FirstOrDefaultAsync(u => u.TransactionId == id);
            if (TransactionFromDb == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            tranDb.Transaction.Remove(TransactionFromDb);
            await tranDb.SaveChangesAsync();
            return Json(new { success = true, message = "Delete successful" });
        }
    }
}