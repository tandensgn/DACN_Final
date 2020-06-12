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
            var date = DateTime.Now;

            customer cus = new customer()
            {
                cus_name = sco.cusName,
                cus_phone = sco.cusPhone,
                cus_email = sco.cusEmail,
                cus_address = sco.cusAddress
            };
            db.customers.Add(cus);
            db.SaveChanges();

            order or = new order()
            {
                cus_id = cus.cus_id,
                or_date = date,
                or_status = "Order Receiving",
                or_total = sco.scQty * sco.scPrice
            };
            db.orders.Add(or);
            db.SaveChanges();

            orderdetail ord = new orderdetail()
            {
                or_id = or.or_id,
                prod_id = sco.scProdID,
                ord_qty = sco.scQty,
                ord_price = sco.scPrice,
                ord_sale = 0,
                ord_total = sco.scQty*sco.scPrice
            };
            db.orderdetails.Add(ord);
            db.SaveChanges();

            Response response = new Response()
            {
                IsSuccess = true,
                ErrorCode = "200",
                Message = "Order successfully"
            };
            return Json(JsonConvert.SerializeObject(response));
        }

    }
}