using System;
using System.Collections.Generic;
using System.Linq;
using PhanBaoAn.Context;
using System.Web;

namespace PhanBaoAn.Models
{
    public class HomeModel
    {
        public List<product> ListProduct { get; set; }
        public List<category> ListCategory { get; set; }
    }
} 