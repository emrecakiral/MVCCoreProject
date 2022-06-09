using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCCoreProject.Models.Entities;
using MVCCoreProject.Models.Repository;
using MVCCoreProject.Models.ViewModels;

namespace MVCCoreProject.Controllers
{
    public class CategoryManageController : Controller
    {
        //IRepository<Category> repository;
        CategoryRepository repository;
        IMapper mapper; // AutoMapper kütüphganesinden gelen interface...program.cs dosyasına geçip IMapperi inject edelim...
        public CategoryManageController(CategoryRepository _repository,
            IMapper _mapper)
        {
            repository = _repository;
            mapper = _mapper;
        }

        // GET: CategroyManageController
        public ActionResult Index()
        {

            #region Aciklama
            // view farklı model beklediği için, repository'den gelen model listesinin verilerini alıp view'ın beklediği model listesine ekledik. Ancak bu işlemi projedeki bütün yapılara uygulamak gereksiz kod (kirli) oluşturuacaktır...Bunun yerine ViewModellerimiz ile Veirtabanı modellerimizi otomatik eşleştiren bir yapı kullanırsak işlemlerimizi daha kısa sürede ve temiz bir şekilde yapabiliriz.. Bunun için projemizi gidip AutoMapper kütüphanesini indiriyoruz.. AutoMapper kütüphanesi belirtilen sınıflarının alanları maplemek için kullanılır. Araştırınız...


            //List<CategoryViewModel> vmList = new List<CategoryViewModel>();
            //var list = repository.GetAll();

            //foreach (var item in list)
            //{
            //    CategoryViewModel model = new CategoryViewModel();
            //    model.Id = item.Id;
            //    model.Name = item.Name;
            //    model.Description = item.Description;

            //    vmList.Add(model);
            //}
            #endregion
            List<CategoryViewModel> vmList = mapper.Map<List<CategoryViewModel>>(repository.GetAll());
            return View(vmList);
        }

        // GET: CategroyManageController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategroyManageController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category model)
        {
            try
            {
                repository.Add(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategroyManageController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CategroyManageController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategroyManageController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategroyManageController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
