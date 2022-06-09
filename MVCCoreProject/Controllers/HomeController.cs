using Microsoft.AspNetCore.Mvc;
using MVCCoreProject.Models.Entities;

namespace MVCCoreProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly NorthwindDbContext dbContext;
        public HomeController(NorthwindDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public IActionResult Index()
        {
            var c = dbContext.Category.ToList();

            return View();
        }
    }
}
