using DACN_SalePhone_Final.HttpResponse;
using DACN_SalePhone_Final.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static DACN_SalePhone_Final.Models.ShoppingCartOrder;

namespace DACN_SalePhone_Final.Controllers
{
    public class ShoppingController : Controller
    {

        qlbdtDbEntities db = new qlbdtDbEntities();
        
        // Shopping Cart
        public ActionResult ShoppingCart(int prodID)
        {
            ShoppingCartOrder shoppingCart = (from p in db.products
                                         where p.prod_id == prodID
                                         select new ShoppingCartOrder()
                                         {
                                             scProdID = p.prod_id,
                                             orID = 0,
                                             scQty = 1,
                                             scProdName = p.prod_name,
                                             scPrice = p.prod_price,
                                             scTotal = p.prod_price,
                                             scProdIcon = p.prod_icon
                                         }).First();
            ViewBag.shoppingCart = shoppingCart;
            return View(shoppingCart);
        }
        [HttpPost]
        public JsonResult ShoppingCart(ShoppingCartOrder shoppingCartOrder)
        {
            ShoppingCartOrder sco = shoppingCartOrder;

            customer cus = new customer()
            {
                cus_name = sco.cusName,
                cus_phone = sco.cusPhone,
                cus_email = sco.cusEmail,
                cus_address = sco.cusAddress
            };
            db.customers.Add(cus);
            db.SaveChanges();

            Response response = new Response()
            {
                IsSuccess = true,
                ErrorCode = "200",
                Message = "successfully"
            };
            return Json(JsonConvert.SerializeObject(response));
        }

    }
}