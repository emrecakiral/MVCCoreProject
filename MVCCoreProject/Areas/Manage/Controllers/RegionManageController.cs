using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCCoreProject.Areas.Manage.Models.ViewModels;
using MVCCoreProject.Models.Entities;
using MVCCoreProject.Models.Repository;

namespace MVCCoreProject.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class RegionManageController : Controller
    {
        RegionRepository repository;
        IMapper mapper;

        public RegionManageController(RegionRepository _repository, IMapper _mapper)
        {
            repository = _repository;
            mapper = _mapper;
        }
        // GET: RegionManageController
        public ActionResult Index()
        {
            List<RegionViewModel> vmList = mapper.Map<List<RegionViewModel>>(repository.GetAll());
            return View(vmList);
        }

        // GET: RegionManageController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RegionManageController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegionManageController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Region model)
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

        // GET: RegionManageController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RegionManageController/Edit/5
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

        // GET: RegionManageController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RegionManageController/Delete/5
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
