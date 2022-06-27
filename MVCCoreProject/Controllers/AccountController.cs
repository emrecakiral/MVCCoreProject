using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCCoreProject.Models;
using MVCCoreProject.Models.Entities;
using MVCCoreProject.Models.ViewModels;

namespace MVCCoreProject.Controllers
{
    public class AccountController : Controller
    {
        // UserManager,RoleManager sınıfları ile kullanıcılar ve rollerini yönetebiliriz..

        UserManager<AppUser> _userManager; // kullanıcıları yönetmek için kullanlık
        RoleManager<AppRole> _roleManager; // rolleri yönetmek için kullanılır
        public AccountController(
            UserManager<AppUser> userManager,
            RoleManager<AppRole> roleManager
            )
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserVM model)
        {
            AppUser user = new AppUser();
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Adres1 = model.Adres1;
            user.Adres2 = model.Adres2;
            user.Email = model.Email;
            user.UserName = model.UserName;
            user.City = model.City;
            user.Town = model.Town;


            // Create Metodu veritabanında AspNetUser tablosunda kullanıcıyı oluştacaktır..
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Errors.Count() > 0)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description); // hataları view'a dön
                }
                return View(model);
            }

            // oturum açacağız...
            return RedirectToAction("Index", "Home");

        }
    }
}
