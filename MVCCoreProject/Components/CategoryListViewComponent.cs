using Microsoft.AspNetCore.Mvc;
using MVCCoreProject.Models.Repository;

namespace MVCCoreProject.Components
{
    public class CategoryListViewComponent : ViewComponent
    {

        private readonly CategoryRepository repository;
        public CategoryListViewComponent(CategoryRepository _repository)
        {
            repository = _repository;
        }

        public IViewComponentResult Invoke()
        {
            var result = repository.GetAll();
            return View(result);

        }
    }
}
