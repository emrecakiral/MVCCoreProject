using Microsoft.AspNetCore.Mvc;

namespace MVCCoreProject.Controllers
{
    public class PermissionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
