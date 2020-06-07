using DACN_SalePhone_Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DACN_SalePhone_Final.Controllers
{
    public class ProductsController : Controller
    {
        qlbdtDbEntities db = new qlbdtDbEntities();
        // GET: Products
        public ActionResult ProductListByCate(int cateID)
        {
            var productInfo = from i in db.products
                              where i.cate_id == cateID
                              select new ProductsInfo()
                              {
                                  productID = i.prod_id,
                                  cateID = i.cate_id,
                                  productName = i.prod_name,
                                  productIcon = i.prod_icon,
                                  productImage = i.prod_image,
                                  productReprice = (int)i.prod_reprice,
                                  productPrice = i.prod_price,
                                  productWarranty = i.prod_warranty,
                                  productAccessories = i.prod_accessories,
                                  productCondition = i.prod_condition,
                                  productPromotion = i.prod_promotion,
                                  productStatus = i.prod_status,
                                  productDescription = i.prod_description,
                                  productFeatured = i.prod_featured,
                                  productScreen = i.prod_screen,
                                  productOs = i.prod_os,
                                  productCamf = i.prod_camf,
                                  productCamr = i.prod_camr,
                                  productCpu = i.prod_cpu,
                                  productRam = i.prod_ram,
                                  productImemory = i.prod_Imemory,
                                  productEmemory = i.prod_Ememory,
                                  productSim = i.prod_sim,
                                  productPin = i.prod_pin,
                              };
            var categoriesList = from i in db.categories
                                 where i.cate_id == cateID
                                 select new CategoriesList()
                                 {
                                     cateID = i.cate_id,
                                     cateSeries = i.cate_series
                                 };
            var cate = categoriesList.First();
            ViewBag.cateSeries = cate.cateSeries;
            var productListByCategories = new ProductListByCategories()
            {
                productInfo = productInfo.ToArray(),
                categoriesList = categoriesList.ToArray(),
            };
            return View(productListByCategories);
        }
        public ActionResult ProductDetail(int prodID)
        {
            ProductsAndCategories productsQuery = (from p in db.products
                                                   join c in db.categories on p.cate_id equals c.cate_id
                                                   where p.prod_id == prodID
                                                   select new ProductsAndCategories()
                                                   {
                                                       productID = p.prod_id,
                                                       cateID = p.cate_id,
                                                       productName = p.prod_name,
                                                       productIcon = p.prod_icon,
                                                       productImage = p.prod_image,
                                                       productReprice = (int)p.prod_reprice,
                                                       productPrice = p.prod_price,
                                                       productWarranty = p.prod_warranty,
                                                       productAccessories = p.prod_accessories,
                                                       productCondition = p.prod_condition,
                                                       productPromotion = p.prod_promotion,
                                                       productStatus = p.prod_status,
                                                       productDescription = p.prod_description,
                                                       productFeatured = p.prod_featured,
                                                       productScreen = p.prod_screen,
                                                       productOs = p.prod_os,
                                                       productCamf = p.prod_camf,
                                                       productCamr = p.prod_camr,
                                                       productCpu = p.prod_cpu,
                                                       productRam = p.prod_ram,
                                                       productImemory = p.prod_Imemory,
                                                       productEmemory = p.prod_Ememory,
                                                       productSim = p.prod_sim,
                                                       productPin = p.prod_pin,
                                                       cateSeries = c.cate_series
                                                   }).FirstOrDefault();
            ViewBag.prodName = productsQuery;
            return View(productsQuery);
        }
    }
}