using DACN_SalePhone_Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static DACN_SalePhone_Final.Models.IndexProducts;

namespace DACN_SalePhone_Final.Controllers
{
    public class HomeController : Controller
    {
        qlbdtDbEntities db = new qlbdtDbEntities();

        public IEnumerable<product> getProduct(int cateID)
        {
            var productGender = (from i in db.products
                                where i.cate_id == cateID
                                select i).Take(4);
            var categoriesList = from i in db.categories
                                 where i.cate_id == cateID
                                 select new CategoriesList()
                                 {
                                     cateID = i.cate_id,
                                     cateSeries = i.cate_series
                                 };
            var cate = categoriesList.First();
            ViewBag.cateSeries = cate.cateSeries;
            return productGender;
        }
        public ActionResult Index()
        {
            var indexProduct1s = getProduct(1);
            var indexProduct2s = getProduct(2);

            var indexProduct = new IndexProducts()
            {
                indexProduct1 = indexProduct1s.ToArray(),
                indexProduct2 = indexProduct2s.ToArray()
            };

            return View(indexProduct);
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