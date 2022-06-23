using Microsoft.AspNetCore.Mvc;
using MVCCoreProject.Models;
using System.Text.Json;

namespace MVCCoreProject.Components
{
    public class CartItemHeaderViewComponent : ViewComponent
    {


        public IViewComponentResult Invoke()
        {
            List<CartItem> cartItemList = new List<CartItem>();

            if (HttpContext.Request.Cookies["sepet"] != null)
            {
                // cookiden çıkart catItemList nesnesine ata...
                string s = HttpContext.Request.Cookies["sepet"];
                cartItemList = JsonSerializer.Deserialize<List<CartItem>>(s);
            }
            return View(cartItemList);
        }
    }
}
