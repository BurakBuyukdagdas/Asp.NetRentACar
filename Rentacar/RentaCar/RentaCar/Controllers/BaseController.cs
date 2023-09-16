using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentaCar.Models;

namespace RentaCar.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        u1400114_dbA9AEntities db = new u1400114_dbA9AEntities();
        public BaseController()
        {
            ViewBag.Telefon = db.tbl_Ayarlar.FirstOrDefault(t => t.ID == 2).TelefonNo;
            ViewBag.Mail = db.tbl_Ayarlar.FirstOrDefault(t => t.ID == 2).Mail;
            ViewBag.Adres = db.tbl_Ayarlar.FirstOrDefault(t => t.ID == 2).Adres;
            ViewBag.Aciklama = db.tbl_Ayarlar.FirstOrDefault(t => t.ID == 2).KısaAciklama;
            
        }
    }
}