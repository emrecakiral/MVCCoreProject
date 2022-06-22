using Microsoft.AspNetCore.Mvc;
using MVCCoreProject.Models.Entities;
using MVCCoreProject.Models.Repository;

namespace MVCCoreProject.Controllers
{
    public class HomeController : Controller
    {
        readonly ProductsRepository _productsRepository;
        public HomeController(ProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Search(string productname)
        {
            var result = new List<Products>();

            if (!string.IsNullOrWhiteSpace(productname))
            {
                result = _productsRepository.FindByCriter(c => c.ProductName.ToLower().Contains(productname.ToLower()));
            }

            return View("SearchProductList", result);
        }
    }
}
