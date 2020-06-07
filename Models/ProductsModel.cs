using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DACN_SalePhone_Final.Models
{
    public class CategoriesList
    {
        public int cateID { set; get; }
        public string cateSeries { set; get; }
    }
    public class ProductsInfo
    {
        public int productID { set; get; }
        public int cateID { set; get; }
        public string productName { set; get; }
        public string productIcon { set; get; }
        public string productImage { set; get; }
        public int productReprice { set; get; }
        public int productPrice { set; get; }
        public string productWarranty { set; get; }
        public string productAccessories { set; get; }
        public string productCondition { set; get; }
        public string productPromotion { set; get; }
        public int productStatus { set; get; }
        public string productDescription { set; get; }
        public int productFeatured { set; get; }
        public string productScreen { set; get; }
        public string productOs { set; get; }
        public string productCamf { set; get; }
        public string productCamr { set; get; }
        public string productCpu { set; get; }
        public string productRam { set; get; }
        public string productImemory { set; get; }
        public string productEmemory { set; get; }
        public string productSim { set; get; }
        public string productPin { set; get; }
    }

    public class ProductListByCategories
    {
        public IEnumerable<ProductsInfo> productInfo { get; set; }
        public IEnumerable<CategoriesList> categoriesList { get; set; }
    }

    public class ProductsAndCategories
    {
        public int productID { set; get; }
        public int cateID { set; get; }
        public string productName { set; get; }
        public string productIcon { set; get; }
        public string productImage { set; get; }
        public int productReprice { set; get; }
        public int productPrice { set; get; }
        public string productWarranty { set; get; }
        public string productAccessories { set; get; }
        public string productCondition { set; get; }
        public string productPromotion { set; get; }
        public int productStatus { set; get; }
        public string productDescription { set; get; }
        public int productFeatured { set; get; }
        public string productScreen { set; get; }
        public string productOs { set; get; }
        public string productCamf { set; get; }
        public string productCamr { set; get; }
        public string productCpu { set; get; }
        public string productRam { set; get; }
        public string productImemory { set; get; }
        public string productEmemory { set; get; }
        public string productSim { set; get; }
        public string productPin { set; get; }
        public string cateSeries { set; get; }
    }
}