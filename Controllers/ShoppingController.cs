using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DACN_SalePhone_Final.Controllers
{
    public class ShoppingController : Controller
    {
        // GET: Shopping
        public ActionResult ShoppingCart()
        {
            return View();
        }
    }
}