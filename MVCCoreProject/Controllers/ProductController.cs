using Microsoft.AspNetCore.Mvc;
using MVCCoreProject.Models.Entities;
using MVCCoreProject.Models.Repository;
using System.Text.Json;

namespace MVCCoreProject.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductsRepository repository;
        public ProductController(ProductsRepository _repository)
        {
            repository = _repository;
        }

        public IActionResult Index(int categoryid)
        {
            //var list = repositorty.GetAll().Where(c => c.CategoryID == categoryid).ToList();

            var list = repository.FindByCriter(c => c.CategoryID == categoryid);
            return View(list);
        }

        public IActionResult Detail(int productId)
        {

            Products product = repository.Get(productId);


            // son görüntülenlere eklemesi için....
            AddReviewProduct(productId);


            return View(product);
        }

        private void AddReviewProduct(int productId)
        {
            List<string> ids = new List<string>();
            if (HttpContext.Request.Cookies["productIds"] != null)
            {
                string cookiestr = HttpContext.Request.Cookies["productIds"];
                ids = JsonSerializer.Deserialize<List<string>>(cookiestr);
            }

            if (ids.IndexOf(productId.ToString()) == -1) // eğer dizide yoksa...
            {
                ids.Add(productId.ToString());
                var str = JsonSerializer.Serialize(ids);
                HttpContext.Response.Cookies.Append("productIds", str);
            }
            // [1,2,3,4,5,6,7]


        }
    }
}