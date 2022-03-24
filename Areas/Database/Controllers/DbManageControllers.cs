using System.Threading.Tasks;
using App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Database
{
    [Area("Database")]


    public class DbManage : Controller
    {
        private readonly AppDbContext dbContext;
        [TempData]
        public string StatusMessage { set; get; }

        public DbManage(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]

        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteAsync()
        {
            var success = await dbContext.Database.EnsureDeletedAsync();

            if (!success)
            {
                StatusMessage = "Deleting database failed";
                return RedirectToAction(nameof(Index));
            }
            StatusMessage = "Delete database successfully";
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Migrate()
        {
            await dbContext.Database.MigrateAsync();

            StatusMessage = $"Migrate database {dbContext.Database.GetDbConnection().Database} successfully";

            return RedirectToAction(nameof(Index));
        }
    }


}