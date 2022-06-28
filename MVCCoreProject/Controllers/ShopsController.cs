using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCCoreProject.Models;
using MVCCoreProject.Models.Repository;

namespace MVCCoreProject.Controllers
{
    [Authorize(Roles = "User")]
    public class ShopsController : Controller
    {
        private readonly UserAddresRepository _userAddresRepository;
        private readonly UserManager<AppUser> _userManager;
        public ShopsController(
             UserManager<AppUser> userManager,
             UserAddresRepository userAddresRepository)
        {
            _userManager = userManager;
            _userAddresRepository = userAddresRepository;
        }

        public async Task<IActionResult> Index()
        {
            var AppUser = await _userManager.FindByNameAsync(User.Identity.Name);

            // Kullanıcının adres listesi
            var list = _userAddresRepository.FindByCriter(c => c.UserId == AppUser.Id && c.Active == true);

            if (list.Count == 0)
            {
                return RedirectToAction("AddAdres", "Account", new { ReturnUrl = "/Shops" });
            }


            return View();
        }

    }
}
