using PagedList;
using RentaCar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentaCar.MVVM
{
    public class AltSayfa
    {
        public IPagedList<tbl_Arac> AracSayfa { get; set; }
        public IPagedList<tbl_Blog> BlogSayfa { get; set; }
        public List<tbl_Hakkimizda> HakkimizdaSayfa { get; set; }
        public List<tbl_Arac> AramaSayfa { get; set; }
    }
}