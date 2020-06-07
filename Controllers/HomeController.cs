using DACN_SalePhone_Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static DACN_SalePhone_Final.Models.CategoriesList;

namespace DACN_SalePhone_Final.Controllers
{
    public class HomeController : Controller
    {
        qlbdtDbEntities db = new qlbdtDbEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AboutUs()
        {
            return View();
        }
        public ActionResult ContactUs()
        {
            return View();
        }


        [ChildActionOnly]
        public ActionResult CategoriesHeader()
        {
            var categories = from i in db.categories
                             select new CategoriesList()
                             {
                                 cateID = i.cate_id,
                                 cateSeries = i.cate_series
                             };
            return PartialView("_header", categories);
        }
        [ChildActionOnly]
        public ActionResult CategoriesFooter()
        {
            var categories = from i in db.categories
                             select new CategoriesList()
                             {
                                 cateID = i.cate_id,
                                 cateSeries = i.cate_series
                             };
            return PartialView("_footer", categories);
        }

    }
}