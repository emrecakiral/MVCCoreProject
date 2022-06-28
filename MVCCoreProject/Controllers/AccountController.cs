using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCCoreProject.Migrations;
using MVCCoreProject.Models;
using MVCCoreProject.Models.Entities;
using MVCCoreProject.Models.Repository;
using MVCCoreProject.Models.ViewModels;

namespace MVCCoreProject.Controllers
{
    [Authorize(Roles = "User")]
    public class AccountController : Controller
    {
        // UserManager,RoleManager sınıfları ile kullanıcılar ve rollerini yönetebiliriz..

        private readonly UserManager<AppUser> _userManager; // kullanıcıları yönetmek için kullanlık
        private readonly RoleManager<AppRole> _roleManager; // rolleri yönetmek için kullanılır
        private readonly SignInManager<AppUser> _signInManager; // oturum yönetimi...
        private readonly UserAddresRepository _userAddresRepository;
        IMapper mapper; // AutoMapper kütüphganesinden gelen interface...program.cs dosyasına geçip IMapperi inject edelim...
        public AccountController(
            UserManager<AppUser> userManager,
            RoleManager<AppRole> roleManager,
            SignInManager<AppUser> signInManager,
            UserAddresRepository userAddresRepository,
            IMapper _mapper
            )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _userAddresRepository = userAddresRepository;
            mapper = _mapper;
        }


        [AllowAnonymous] // Anonim 
        public IActionResult SigIn(string ReturnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Profile");
            }

            // tempdata actionda view'a veya actiondan action'a veri göndermek için kullanılır..ViewBag'a göre daha uzun ömürlüdür. Bİr sonraki requestten de erişelebilir..
            TempData["returnUrl"] = ReturnUrl;
            return View();
        }

        [AllowAnonymous] // Anonim 
        [HttpPost]
        public async Task<IActionResult> SigIn(UserVM model)
        {


            // username göre ara...
            AppUser user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                ModelState.AddModelError("", "Kullanıcı Bulanamadı");
                return View(model);
            }

            // oturum açacağız...
            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Hatalı şifre. Lütfen tekrar deneyiniz");
                return View(model);
            }

            string rUrl = (string)TempData["returnUrl"];
            if (rUrl != null)
                return Redirect(rUrl); // Controller/Action
            else
                return RedirectToAction("Index", "Home");  // anasayfaya yönlendir...
            //return Redirect("/Home/Index");

        }

        [AllowAnonymous] // Anonim 
        public IActionResult LogOut()
        {
            _signInManager.SignOutAsync(); // oturumu kapat...
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous] // Anonim 
        public IActionResult Register()
        {
            return View();
        }

        [AllowAnonymous] // Anonim 
        [HttpPost]
        public async Task<IActionResult> Register(UserVM model)
        {
            AppUser user = new AppUser();
            user.UserName = model.UserName;
            user.Email = model.Email;

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


            if (!await _roleManager.RoleExistsAsync("Admin")) // admin role yoksa
            {
                AppRole role = new AppRole();
                role.Name = "Admin";

                await _roleManager.CreateAsync(role); // rolü oluştur...
            }

            if (!await _roleManager.RoleExistsAsync("User")) // User role yoksa...
            {
                AppRole role = new AppRole();
                role.Name = "User";
                await _roleManager.CreateAsync(role);
            }


            if (model.UserName == "eyildirim")
            {
                await _userManager.AddToRoleAsync(user, "Admin"); //Admin rolünü ekle
            }

            await _userManager.AddToRoleAsync(user, "User"); // User rolünü ekle

            // oturum açacağız...
            await _signInManager.PasswordSignInAsync(user, model.Password, false, false);

            return RedirectToAction("Index", "Home");
        }


        public async Task<IActionResult> Profile()
        {
            //User.Identity.Name; // userName
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            return View(user);

        }

        [HttpPost]
        public async Task<IActionResult> Profile(AppUser model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            user.Email = model.Email;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;

            // Create Metodu veritabanında AspNetUser tablosunda kullanıcıyı oluştacaktır..
            var result = await _userManager.UpdateAsync(user);

            if (result.Errors.Count() > 0)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description); // hataları view'a dön
                }
                return View(model);
            }

            ViewBag.Message = "İşlem Başarılı";

            // oturum açacağız...
            return View();
        }

        public async Task<IActionResult> Adreslerim()
        {
            var AppUser = await _userManager.FindByNameAsync(User.Identity.Name);

            // Kullanıcının adres listesi
            var list = _userAddresRepository.FindByCriter(c => c.UserId == AppUser.Id && c.Active == true);

            List<UserAdressVM> result = mapper.Map<List<UserAdressVM>>(list);
            return View(result);
        }


        public IActionResult AddAdres(string ReturnUrl)
        {
            TempData["returnUrl"] = ReturnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAdres(UserAdressVM vm)
        {
            UserAddres model = mapper.Map<UserAddres>(vm);
            model.Active = true;

            var AppUser = await _userManager.FindByNameAsync(User.Identity.Name);
            model.UserId = AppUser.Id;

            try
            {
                _userAddresRepository.Add(model);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Bir Hata OLuştu");
                return View();
            }

            string returnUrl = (string)TempData["returnUrl"];

            if (returnUrl != null)
                return Redirect(returnUrl);


            return RedirectToAction("Adreslerim");
        }



        public async Task<IActionResult> DeleteAdres(int id)
        {
            try
            {
                UserAddres model = _userAddresRepository.Get(id);
                _userAddresRepository.Delete(model);
            }
            catch (Exception)
            {
            }
            return RedirectToAction("Adreslerim");
        }

    }
}