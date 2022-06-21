using Microsoft.AspNetCore.Mvc;
using MVCCoreProject.Models.Entities;
using MVCCoreProject.Models.Repository;
using MVCCoreProject.Models.ViewModels;

namespace MVCCoreProject.Components
{
    public class ProductDiscountListViewComponent : ViewComponent
    {
        ProductDiscountRepository _productDiscountRepository;
        ProductsRepository _productsRepository;
        public ProductDiscountListViewComponent(
            ProductDiscountRepository productDiscountRepository,
           ProductsRepository productsRepository)
        {
            _productDiscountRepository = productDiscountRepository;
            _productsRepository = productsRepository;
        }

        public IViewComponentResult Invoke()
        {
            List<ProductDiscountVM> modelList = new List<ProductDiscountVM>();

            var result = _productDiscountRepository.GetAll();
            foreach (var item in result)
            {
                Products prod = _productsRepository.Get(item.ProductId);

                ProductDiscountVM model = new ProductDiscountVM();
                model.ProductID = prod.ProductID;
                model.CategoryName = prod.Category.Name;
                model.ProductName = prod.ProductName;
                model.OldPrice = prod.UnitPrice;
                model.Discount = item.Discount;
                modelList.Add(model);
            }

            return View(modelList);
        }
    }
}
