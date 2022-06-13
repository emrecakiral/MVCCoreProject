using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCCoreProject.Models.Entities;
using MVCCoreProject.Models.Repository;
using MVCCoreProject.Models.ViewModels;

namespace MVCCoreProject.Controllers
{
    public class CustomerManageController : Controller
    {
        CustomerRepository repository;
        IMapper mapper;

        public CustomerManageController(CustomerRepository _repository, IMapper _mapper)
        {
            repository = _repository;
            mapper = _mapper;
        }

        // GET: CustomerManageController
        public ActionResult Index()
        {
            List<CustomerViewModel> vmList = mapper.Map<List<CustomerViewModel>>(repository.GetAll());
            return View(vmList);
        }

        // GET: CustomerManageController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerManageController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer model)
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

        // GET: CustomerManageController/Edit/5
        public ActionResult Edit(int id)
        {
            CustomerViewModel model = mapper.Map<CustomerViewModel>(repository.Get(id));
            return View(model);
        }

        // POST: CustomerManageController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Customer model)
        {
            try
            {
                model = repository.Get(id);
                repository.Update(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerManageController/Delete/5
        public ActionResult Delete(int id)
        {
            CustomerViewModel model = mapper.Map<CustomerViewModel>(repository.Get(id));
            return View(model);
        }

        // POST: CustomerManageController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Customer model)
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
            CustomerViewModel model = mapper.Map<CustomerViewModel>(repository.Get(id));
            return View(model);
        }
    }
}
