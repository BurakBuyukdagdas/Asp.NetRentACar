using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using RentaCar.Models;
using PagedList;

namespace RentaCar.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin

        u1400114_dbA9AEntities model = new u1400114_dbA9AEntities();
        [Authorize]
        public ActionResult Index(int? page)
        {
            int pageSize = 10;  //Her sayfada 10 adet araç görünecek.
            int pageNumber = (page ?? 1);
            var aracListesi = model.tbl_Arac.OrderBy(a => a.AracID).ToPagedList(pageNumber, pageSize);
            return View(aracListesi);
        }

        [HttpGet]
        public ActionResult YeniAracEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniAracEkle(tbl_Arac b)
        {
            var existingTip = model.tbl_Aracturu.FirstOrDefault(t => t.TipAdi == b.tbl_Aracturu.TipAdi);
            var existingMarka = model.tbl_marka.FirstOrDefault(m => m.MarkaAdi == b.tbl_marka.MarkaAdi);

            if (existingTip != null)
            {
                // Mevcut Araç Türü kullanılacak
                b.tbl_Aracturu = existingTip;
            }

            if (existingMarka != null)
            {
                // Mevcut Marka kullanılacak
                b.tbl_marka = existingMarka;
            }

            model.tbl_Arac.Add(b);
            model.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AracSil(int id)
        {
            var a = model.tbl_Arac.Find(id);
            model.tbl_Arac.Remove(a);
            model.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AracGetir(int id)
        {
            var a = model.tbl_Arac.Find(id);
            return View("AracGetir",a);
        }
        public ActionResult AracGuncelle(tbl_Arac b)
        {
            var a =model.tbl_Arac.Find(b.AracID);
            a.Aciklama = b.Aciklama;
            a.Aktifmi=b.Aktifmi;
            a.Fiyati = b.Fiyati;
            a.Rengi = b.Rengi;
            a.Vitesi = b.Vitesi;
            a.Gorsel = b.Gorsel;
            a.Onecikanlar = b.Onecikanlar;
            a.tbl_marka.MarkaAdi = b.tbl_marka.MarkaAdi;
            a.tbl_Aracturu.TipAdi = b.tbl_Aracturu.TipAdi;
            model.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Marka()
        {
            List<tbl_marka> MarkaListesi = model.tbl_marka.ToList();
            return View(MarkaListesi);
        }
        [HttpGet]
        public ActionResult YeniMarka()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMarka(tbl_marka p)
        {
            model.tbl_marka.Add(p);
            model.SaveChanges();
            return RedirectToAction("Marka");
        }
        public ActionResult MarkaSil(int id)
        {
            var a = model.tbl_marka.Find(id);
            model.tbl_marka.Remove(a);
            model.SaveChanges();
            return RedirectToAction("Marka");
        }
        public ActionResult MarkaGetir(int id)
        {
            var a = model.tbl_marka.Find(id);
            return View("MarkaGetir", a);
        }
        public ActionResult MarkaGuncelle(tbl_marka b)
        {
            var a = model.tbl_marka.Find(b.MarkaID);
            a.MarkaAdi = b.MarkaAdi;
            model.SaveChanges();
            return RedirectToAction("Marka");
        }

        public ActionResult AracTuru()
        {
            List<tbl_Aracturu> TurListesi = model.tbl_Aracturu.ToList();
            return View(TurListesi);
        }
        [HttpGet]
        public ActionResult YeniTur()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniTur(tbl_Aracturu p)
        {
            model.tbl_Aracturu.Add(p);
            model.SaveChanges();
            return RedirectToAction("AracTuru");
        }

        public ActionResult TurSil(int id)
        {
            var a = model.tbl_Aracturu.Find(id);
            model.tbl_Aracturu.Remove(a);
            model.SaveChanges();
            return RedirectToAction("AracTuru");
        }
        public ActionResult TurGetir(int id)
        {
            var a = model.tbl_Aracturu.Find(id);
            return View("TurGetir", a);
        }
        public ActionResult TurGuncelle(tbl_Aracturu b)
        {
            var a = model.tbl_Aracturu.Find(b.TipID);
            a.TipAdi = b.TipAdi;
            model.SaveChanges();
            return RedirectToAction("AracTuru");
        }
        public ActionResult Blog()
        {
            var degerler = model.tbl_Blog.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniBlog()
        {
            return View();
        }


        [HttpPost]
        public ActionResult YeniBlog(tbl_Blog p)
        {
            model.tbl_Blog.Add(p);
            model.SaveChanges();
            return RedirectToAction("Blog");
        }
        public ActionResult BlogSil(int id)
        {
            var a = model.tbl_Blog.Find(id);
            model.tbl_Blog.Remove(a);
            model.SaveChanges();
            return RedirectToAction("Blog");
        }
        public ActionResult BlogGetir(int id)
        {
            var a = model.tbl_Blog.Find(id);
            return View("BlogGetir", a);
        }
        public ActionResult BlogGuncelle(tbl_Blog b)
        {
            var a = model.tbl_Blog.Find(b.ID);
            a.Aciklama = b.Aciklama;
            a.Baslik = b.Baslik;
            a.Tarih = b.Tarih;
            a.BlogImage = b.BlogImage;
            a.Onecikan = b.Onecikan;
            model.SaveChanges();
            return RedirectToAction("Blog");
        }







        public ActionResult HakkimizdaSayfasi()
        {
            List<tbl_Hakkimizda> HakkimizdaSayfasi = model.tbl_Hakkimizda.ToList();
            return View(HakkimizdaSayfasi);
        }
        [HttpGet]
        public ActionResult YeniHakkimizda()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniHakkimizda(tbl_Hakkimizda p)
        {
            model.tbl_Hakkimizda.Add(p);
            model.SaveChanges();
            return RedirectToAction("HakkimizdaSayfasi");
        }

        public ActionResult HakkimizdaSil(int id)
        {
            var a = model.tbl_Hakkimizda.Find(id);
            model.tbl_Hakkimizda.Remove(a);
            model.SaveChanges();
            return RedirectToAction("HakkimizdaSayfasi");
        }

        public ActionResult HakkimizdaGetir(int id)
        {
            var a = model.tbl_Hakkimizda.Find(id);
            return View("HakkimizdaGetir", a);
        }
        public ActionResult HakkimizdaGuncelle(tbl_Hakkimizda b)
        {
            var a = model.tbl_Hakkimizda.Find(b.ID);
            a.Aciklama = b.Aciklama;
            model.SaveChanges();
            return RedirectToAction("HakkimizdaSayfasi");
        }





        public ActionResult iletisim()
        {
            List<tbl_Ayarlar> iletisim = model.tbl_Ayarlar.ToList();
            return View(iletisim);
        }


        
        public ActionResult iletisimGetir(int id)
        {
            var a = model.tbl_Ayarlar.Find(id);
            return View("iletisimGetir", a);
        }
        public ActionResult iletisimGuncelle(tbl_Ayarlar b)
        {
            var a = model.tbl_Ayarlar.Find(b.ID);
            a.TelefonNo = b.TelefonNo;
            a.Mail = b.Mail;
            a.Adres = b.Adres;
            a.KısaAciklama = b.KısaAciklama;
            model.SaveChanges();
            return RedirectToAction("iletisim");
        }
    }
}