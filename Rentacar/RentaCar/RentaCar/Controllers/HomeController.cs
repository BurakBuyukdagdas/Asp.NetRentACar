using RentaCar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentaCar.MVVM;
using PagedList;
using System.Web.UI;

namespace RentaCar.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        cls_Araclar cu = new cls_Araclar();
        AnaSayfaModel ans =new AnaSayfaModel();
        AltSayfa als = new AltSayfa();
        u1400114_dbA9AEntities db = new u1400114_dbA9AEntities();

        public ActionResult Index()
        {
            //List<tbl_Arac> AracVitrin = cu.Vitrin(); Burası AnasayfaModel Tanımlamadan önceydi(Kalıtsallık)
            ans.AracVitrin = cu.Vitrin();
            ans.BlogVitrin = cu.BlogVitrin();
            return View(ans);
        }
        public HomeController()
        {
            string telefon = ViewBag.Telefon;
            string Mail = ViewBag.Mail;
            string Adres = ViewBag.Adres;
            string KısaAciklama = ViewBag.KısaAciklama;
        }
        public ActionResult About()
        {
            als.HakkimizdaSayfa = cu.HakkimizdaSayfa();
            return View(als);
        }
        public ActionResult Hizmetlerimiz()
        {
            return View();
        }
        public ActionResult Araclarimiz(int? page)
        {
            int pageSize = 6; // Her sayfada gösterilecek araç sayısı
            int pageNumber = (page ?? 1); // Sayfa 1 den başlaması için 

            als.AracSayfa = cu.AracSayfasi().ToPagedList(pageNumber, pageSize);

            return View(als);
        }
        public ActionResult AracDetay(int id)
        {
            // Veritabanından ilgili blogu ID'ye göre çekin
            var arac = cu.GetAracById(id);

            // BlogDetay sayfasına blog öğesini gönderin
            return View(arac);
        }


        public ActionResult BLog(int? page)
        {
            int pageSize = 4; //Blog Sayfasında kaç adet geleceği
            int pageNumber = (page ?? 1); //Sayfa 1 den başlaması

            als.BlogSayfa = cu.BlogSayfasi().ToPagedList(pageNumber, pageSize);

            return View(als);
        }


        public ActionResult BlogDetay(int id)
        {
            // Veritabanından ilgili blogu ID'ye göre çekin
            var blog = cu.GetBlogById(id);

            // BlogDetay sayfasına blog öğesini gönderin
            return View(blog);
        }



        public ActionResult iletisim()
        {
            return View();
        }


        public ActionResult AramaEkranı(string aracTuru, string marka)
        {
            cls_Araclar aracIslemleri = new cls_Araclar();
            List<tbl_Arac> aramaSonuclari = aracIslemleri.AramaSonuclari(aracTuru, marka);

            var altSayfaModel = new AltSayfa
            {
                AramaSayfa = aramaSonuclari
            };

            return View(altSayfaModel);
        }

    }
}