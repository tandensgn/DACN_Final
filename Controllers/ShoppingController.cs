using DACN_SalePhone_Final.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static DACN_SalePhone_Final.Models.ShoppingCart;

namespace DACN_SalePhone_Final.Controllers
{
    public class ShoppingController : Controller
    {

        qlbdtDbEntities db = new qlbdtDbEntities();
        
        // Shopping Cart
        public ActionResult ShoppingCart(int prodID)
        {
            ShoppingCart shoppingCart = (from p in db.products
                                         where p.prod_id == prodID
                                         select new ShoppingCart()
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

        private SqlConnection con;

        // GET: Home
        public ActionResult AddOrder()
        {

            return View();
        }
        //Post method to add details
        [HttpPost]
        public ActionResult AddOrder(ShoppingCartOrder ord)
        {
            AddDetails(ord);

            return View();
        }

        //To Handle connection related activities
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["qlbdtDbEntities"].ToString();
            con = new SqlConnection(constr);

        }
        //To add Records into database 
        private void AddDetails(ShoppingCartOrder ord)
        {
            connection();
            SqlCommand com = new SqlCommand("AddOrd", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@cusName", ord.cusName);
            com.Parameters.AddWithValue("@cusPhone", ord.cusPhone);
            com.Parameters.AddWithValue("@cusEmail", ord.cusEmail);
            com.Parameters.AddWithValue("@cusAddress", ord.cusAddress);
            com.Parameters.AddWithValue("@prodID", ord.prodID);
            com.Parameters.AddWithValue("@prodQty", ord.prodQty);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();

        }
    }
}