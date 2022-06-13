using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCCoreProject.Areas.Manage.Models.ViewModels;
using MVCCoreProject.Models.Entities;
using MVCCoreProject.Models.Repository;

namespace MVCCoreProject.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ProductsManageController : Controller
    {
        ProductsRepository repository;
        IMapper mapper;

        public ProductsManageController(ProductsRepository _repository, IMapper _mapper)
        {
            repository = _repository;
            mapper = _mapper;
        }

        // GET: ProductsManageController
        public ActionResult Index()
        {
            List<ProductsViewModel> vmList = mapper.Map<List<ProductsViewModel>>(repository.GetAll());
            return View(vmList);
        }

        // GET: ProductsManageController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductsManageController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Products model)
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

        // GET: ProductsManageController/Edit/5
        public ActionResult Edit(int id)
        {
            ProductsViewModel model = mapper.Map<ProductsViewModel>(repository.Get(id));
            return View(model);
        }

        // POST: ProductsManageController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Products model)
        {
            try
            {
                repository.Update(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsManageController/Delete/5
        public ActionResult Delete(int id)
        {
            ProductsViewModel model = mapper.Map<ProductsViewModel>(repository.Get(id));
            return View(model);
        }

        // POST: ProductsManageController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Products model)
        {
            try
            {
                model = repository.Get(id);
                repository.Delete(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            ProductsViewModel model = mapper.Map<ProductsViewModel>(repository.Get(id));
            return View(model);
        }
    }
}
