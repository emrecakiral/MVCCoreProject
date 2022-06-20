using Microsoft.AspNetCore.Mvc;
using MVCCoreProject.Models.Repository;

namespace MVCCoreProject.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductsRepository repositorty;
        public ProductController(ProductsRepository _repositorty)
        {
            repositorty = _repositorty;
        }

        public IActionResult Index(int categoryid)
        {
            //var list = repositorty.GetAll().Where(c => c.CategoryID == categoryid).ToList();

            var list = repositorty.FindByCriter(c => c.CategoryID == categoryid);
            return View(list);
        }
    }
}