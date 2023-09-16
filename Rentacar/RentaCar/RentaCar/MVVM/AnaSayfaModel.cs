using PagedList;
using RentaCar.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using static RentaCar.Models.cls_Araclar;

namespace RentaCar.MVVM
{
    public class AnaSayfaModel
    {
        public List<tbl_Arac> AracVitrin { get; set; }
        public List<tbl_Blog> BlogVitrin { get; set; }
        public DbSet<tbl_Admin> Admins { get; set; }
    }
}