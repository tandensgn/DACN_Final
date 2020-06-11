using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DACN_SalePhone_Final.HttpResponse
{
    public class Response
    {
        public bool IsSuccess { get; set; }
        public string ErrorCode { get; set; }
        public string Message { get; set; }
    }
}