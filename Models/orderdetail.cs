//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DACN_SalePhone_Final.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class orderdetail
    {
        public int ord_id { get; set; }
        public int or_id { get; set; }
        public int prod_id { get; set; }
        public int ord_qty { get; set; }
        public int ord_price { get; set; }
        public int ord_sale { get; set; }
        public int ord_total { get; set; }
    
        public virtual order order { get; set; }
        public virtual product product { get; set; }
    }
}
