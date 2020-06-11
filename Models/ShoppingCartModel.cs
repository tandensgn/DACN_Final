using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DACN_SalePhone_Final.Models
{

    public class ShoppingCart
    {
        public int scProdID { set; get; }
        public int orID { set; get; }
        public int scQty { set; get; }
        public string scProdName { set; get; }
        public int scPrice { set; get; }
        public int scTotal { set; get; }
        public string scProdIcon { set; get; }
    }

    public class OrderDetail
    {
        public int ordID { set; get; }
        public int orID { set; get; }
        public int prodID { set; get; }
        public string ordQty { set; get; }
        public int ordPrice { set; get; }
        public int ordSale { set; get; }
        public int ordTotal { set; get; }

    }
    public class Order
    {
        public int orID { set; get; }
        public int cusID { set; get; }
        public int orDate { set; get; }
        public string orNumber { set; get; }
        public string orStatus { set; get; }
        public int orTotal { set; get; }

    }
    public class Customer
    {
        public int cusID { set; get; }
        public string cusName { set; get; }
        public int cusPhone { set; get; }
        public string cusEmail { set; get; }
        public string cusAddress { set; get; }
    }

    public class ShoppingCartOrder
    {
        public int scProdID { set; get; }
        public int orID { set; get; }
        public int scQty { set; get; }
        public string scProdName { set; get; }
        public int scPrice { set; get; }
        public int scTotal { set; get; }
        public string scProdIcon { set; get; }
        public int cusID { set; get; }
        public string cusName { set; get; }
        public int cusPhone { set; get; }
        public string cusEmail { set; get; }
        public string cusAddress { set; get; }
    }
}