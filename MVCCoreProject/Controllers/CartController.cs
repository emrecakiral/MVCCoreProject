using Microsoft.AspNetCore.Mvc;
using MVCCoreProject.Models;
using MVCCoreProject.Models.Repository;
using System.Text.Json;

namespace MVCCoreProject.Controllers
{
    public class CartController : Controller
    {
        private readonly ProductsRepository _productRepository;
        private readonly ProductDiscountRepository _productDiscountRepository;
        public CartController(
            ProductsRepository productRepository,
             ProductDiscountRepository productDiscountRepository
            )
        {
            _productRepository = productRepository;
            _productDiscountRepository = productDiscountRepository;
        }

        public IActionResult Index()
        {
            List<CartItem> cartItemList = new List<CartItem>();

            if (HttpContext.Request.Cookies["sepet"] != null)
            {
                // cookiden çıkart catItemList nesnesine ata...
                string s = HttpContext.Request.Cookies["sepet"];
                cartItemList = JsonSerializer.Deserialize<List<CartItem>>(s);
            }

            foreach (var item in cartItemList)
            {
                var prod = _productRepository.Get(item.ProductId);
                item.ProductName = prod.ProductName;
            }

            return View(cartItemList);
        }

        public IActionResult AddToCartV2(int productId, int count)
        {
            List<CartItem> cartItemList = new List<CartItem>();

            var product = _productRepository.Get(productId);

            if (HttpContext.Request.Cookies["sepet"] != null)
            {
                // cookiden çıkart catItemList nesnesine ata...
                string s = HttpContext.Request.Cookies["sepet"];
                cartItemList = JsonSerializer.Deserialize<List<CartItem>>(s);
            }

          
            CartItem item = cartItemList.FirstOrDefault(c => c.ProductId == productId);

            if (count == 0)
                cartItemList.Remove(item); // sepetten sil...
            else
                item.Adet = count;

            if (product.UnitPrice == null)
                item.Fiyat = 0;
            else
            {

                var indirimLiProd = _productDiscountRepository.Get(item.ProductId);
                if (indirimLiProd != null) // indirimi var...
                {
                    decimal? indirim = (product.UnitPrice.Value / 100) * indirimLiProd.Discount;
                    decimal? indirimliFiyat = product.UnitPrice - indirim;

                    item.Fiyat = (decimal)indirimliFiyat * item.Adet;
                    item.BirimFiyat = indirimliFiyat;
                }
                else
                {
                    item.Fiyat = (decimal)product.UnitPrice * item.Adet;
                    item.BirimFiyat = (decimal)product.UnitPrice;
                }

            }



            //HttpContext.Response.Cookies.Append("sepet", cartItemList.ToString());
            string str = JsonSerializer.Serialize(cartItemList); // str'den serilize edilmiş haline bakılabilir..
            HttpContext.Response.Cookies.Append("sepet", JsonSerializer.Serialize(cartItemList), new CookieOptions()
            {
                Expires = DateTimeOffset.Now.AddDays(10)
            });

            return Json(cartItemList);

        }



        public IActionResult AddtoCart(int productId)
        {
            List<CartItem> cartItemList = new List<CartItem>();

            var product = _productRepository.Get(productId);

            if (HttpContext.Request.Cookies["sepet"] != null)
            {
                // cookiden çıkart catItemList nesnesine ata...
                string s = HttpContext.Request.Cookies["sepet"];
                cartItemList = JsonSerializer.Deserialize<List<CartItem>>(s);
            }
            CartItem item = cartItemList.FirstOrDefault(c => c.ProductId == productId);
            if (item == null)
            {
                item = new CartItem();
                item.Adet = 1;
                item.ProductId = productId;
                cartItemList.Add(item);
            }
            else
            {
                item.Adet++;
            }

            if (product.UnitPrice == null)
                item.Fiyat = 0;
            else
            {

                var indirimLiProd = _productDiscountRepository.Get(item.ProductId);
                if (indirimLiProd != null) // indirimi var...
                {
                    decimal? indirim = (product.UnitPrice.Value / 100) * indirimLiProd.Discount;
                    decimal? indirimliFiyat = product.UnitPrice - indirim;

                    item.Fiyat = (decimal)indirimliFiyat * item.Adet;
                    item.BirimFiyat = indirimliFiyat;
                }
                else
                {
                    item.Fiyat = (decimal)product.UnitPrice * item.Adet;
                    item.BirimFiyat = (decimal)product.UnitPrice;
                }

            }



            //HttpContext.Response.Cookies.Append("sepet", cartItemList.ToString());
            string str = JsonSerializer.Serialize(cartItemList); // str'den serilize edilmiş haline bakılabilir..
            HttpContext.Response.Cookies.Append("sepet", JsonSerializer.Serialize(cartItemList), new CookieOptions()
            {
                Expires = DateTimeOffset.Now.AddDays(10)
            });

            return Json(cartItemList);
        }

        public IActionResult RemoveToCart(int productId)
        {
            List<CartItem> cartItemList = new List<CartItem>();
            if (HttpContext.Request.Cookies["sepet"] != null)
            {
                // cookiden çıkart catItemList nesnesine ata...
                string s = HttpContext.Request.Cookies["sepet"];
                cartItemList = JsonSerializer.Deserialize<List<CartItem>>(s);
            }
            var prod = cartItemList.FirstOrDefault(c => c.ProductId == productId);
            cartItemList.Remove(prod);

            HttpContext.Response.Cookies.Append("sepet", JsonSerializer.Serialize(cartItemList), new CookieOptions()
            {
                Expires = DateTimeOffset.Now.AddDays(10)
            });

            return RedirectToAction("Index");
        }
    }
}
