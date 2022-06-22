using Microsoft.AspNetCore.Mvc;
using MVCCoreProject.Models.Entities;
using MVCCoreProject.Models.Repository;
using System.Text.Json;

namespace MVCCoreProject.Components
{
    public class LastReviewProductListViewComponent : ViewComponent
    {
        readonly ProductsRepository _productsRepository;
        public LastReviewProductListViewComponent(ProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public IViewComponentResult Invoke()
        {
            List<Products> modelList = new List<Products>();

            List<string> ids = new List<string>();
            if (HttpContext.Request.Cookies["productIds"] != null)
            {
                ids = JsonSerializer.Deserialize<List<string>>(HttpContext.Request.Cookies["productIds"]);
            }

            foreach (var item in ids)
            {
                Products products = _productsRepository.Get(Convert.ToInt32(item));
                modelList.Add(products);
            }

            return View(modelList);
        }
    }
}
