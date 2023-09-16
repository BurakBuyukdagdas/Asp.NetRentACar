using RentaCar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace RentaCar.Controllers
{
    public class GirisYapController : Controller
    {
        // GET: GirisYap
        u1400114_dbA9AEntities model = new u1400114_dbA9AEntities();
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(tbl_Admin ad)
        {
            var bilgiler = model.tbl_Admin.FirstOrDefault(x => x.KullaniciAdin == ad.KullaniciAdin && x.Sifre == ad.Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KullaniciAdin,false);
                Session["KullaniciAdin"] = bilgiler.KullaniciAdin.ToString();
                return RedirectToAction("Index","Admin");
            }
            else
            {
                return View();
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "GirisYap");
        }
    }
}