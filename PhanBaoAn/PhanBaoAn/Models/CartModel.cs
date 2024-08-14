using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhanBaoAn.Context;

namespace PhanBaoAn.Models
{
    public class CartModel
    {
        public product Product { get; set; }
        public int Quantity { get; set; }
    }
}
