using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCCoreProject.Models;
using MVCCoreProject.Models.Repository;
using MVCCoreProject.Models.ViewModels;
using System.Text.Json;

namespace MVCCoreProject.Controllers
{
    [Authorize(Roles = "User")]
    public class ShopsController : Controller
    {
        private readonly UserAddresRepository _userAddresRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly ShippersRepository _shipperRepository;
        public ShopsController(
             UserManager<AppUser> userManager,
             UserAddresRepository userAddresRepository,
             ShippersRepository shipperRepository)
        {
            _userManager = userManager;
            _userAddresRepository = userAddresRepository;
            _shipperRepository = shipperRepository;
        }

        public async Task<IActionResult> ShipTo()
        {
            var AppUser = await _userManager.FindByNameAsync(User.Identity.Name);

            // Kullanıcının adres listesi
            var list = _userAddresRepository.FindByCriter(c => c.UserId == AppUser.Id && c.Active == true);

            if (list.Count == 0)
            {
                return RedirectToAction("AddAdres", "Account", new { ReturnUrl = "/Shops/ShipTo" });
            }

            var result = _shipperRepository.GetAll();
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> ShipTo(int shipId)
        {
            HttpContext.Session.SetInt32("KargoId", shipId);
            return RedirectToAction("Payment");
        }


        public async Task<IActionResult> Payment()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Payment(PaymentVM vm)
        {

            if (HttpContext.Request.Cookies["sepet"] != null)
            {
                // apiye request yapacağız...
                string str = HttpContext.Request.Cookies["sepet"];
                List<CartItem> cartItemList = JsonSerializer.Deserialize<List<CartItem>>(str);

                // toplam tutar
                decimal totalPrice = cartItemList.Sum(c => c.Fiyat);
                ApiPaymentModelcs model = new ApiPaymentModelcs();
                model.nameSurname = vm.Name;
                model.cartNumber = vm.CartNumber;
                model.price = totalPrice;
                model.month = vm.Month;
                model.year = vm.Year;

                string strData = JsonSerializer.Serialize(model);

                HttpRequestMessage message = new HttpRequestMessage();
                //message.RequestUri = new Uri("http://localhost:5227/api/payment"); todo:ApiApp uygulamasının adresini yazıınız...
                message.RequestUri = new Uri("http://localhost:86/api/payment");
                message.Method = HttpMethod.Post;
                message.Content = JsonContent.Create(model);

                HttpClient client = new HttpClient();
                var result = client.Send(message);

                string resultData = await result.Content.ReadAsStringAsync();

                if (result.StatusCode != System.Net.HttpStatusCode.OK) //200 değilse, işlem başarısız
                {
                    ModelState.AddModelError("", "İşlem yapılamadı. Lütfen bankanız ile görüşün");
                    return View(vm);
                }


                // Order tablosuna kayıt atılır...
                var appUser = await _userManager.FindByNameAsync(User.Identity.Name);
                var userAdres = _userAddresRepository.FindByCriter(c => c.UserId == appUser.Id && c.Active == true).FirstOrDefault(); // adreslerden birisi...

                //  appUser.Id; => CustomerID
                //HttpContext.Session.GetInt32("KargoId"); => ShipVia
                //DateTime.Now => OrderDate
                //Adres bilgileri UserAdress tablsoundan alınır...
                //userAdres.Baslik // => ShipName
               // userAdres.Il //ShipCity


                // Orders tablosuna insert yapılır..
                // siparişi veritabanına yaz...
                foreach (var item in cartItemList)
                {
                   // orderdtay tablosuna insert yapılır..
                }


                // orderId sipariş numarası olaran alınır.. Sİpariş takip numarası olarakta kullanıcaya verilir...
                ViewBag.OrderNumber = $"Ödeminiz Başarılı. Sipariş Numaranız {resultData}";


            }
            else
            {
                ModelState.AddModelError("", "Sepet boş");
            }


            return View(vm);
        }
    }
}
