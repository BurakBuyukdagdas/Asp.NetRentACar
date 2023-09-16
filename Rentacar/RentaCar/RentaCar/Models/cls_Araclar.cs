using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using RentaCar.Models;

namespace RentaCar.Models
{
    public class cls_Araclar
    {
        u1400114_dbA9AEntities db = new u1400114_dbA9AEntities();
        public List<tbl_Arac> Vitrin()
        {
            //Anasayfa da yer alan Vitrinde ki ürünleri getirmek için Yazıldı. Onecikanlar == 1 ise vitrinde görünecek.
            List<tbl_Arac> AracVitrin = db.tbl_Arac.Where(x => x.Onecikanlar == 1).ToList(); //take(4) ile veri tabanından 4 ü gelir.
            return AracVitrin;
        }

        public List<tbl_Blog> BlogVitrin()
        {
            var query = db.tbl_Blog.Where(b => b.Onecikan == 1).OrderByDescending(b => b.Tarih).ToList();
            return query;
        }

        public List<tbl_Arac> AracSayfasi()
        {
            //List<tbl_Arac> AracVitrin = db.tbl_Arac.ToList(); 
            //return AracVitrin;
            List<tbl_Arac> AracVitrin = db.tbl_Arac.Where(arac => arac.Aktifmi == 1).ToList();
            return AracVitrin;
        }

        public List<tbl_Blog> BlogSayfasi()
        {
            List<tbl_Blog> BlogSayfa = db.tbl_Blog.OrderByDescending(b => b.Tarih).ToList();
            return BlogSayfa;
        }

        public tbl_Blog GetBlogById(int id)
        {
            return db.tbl_Blog.FirstOrDefault(b => b.ID == id);
        }
        public tbl_Arac GetAracById(int id)
        {
            return db.tbl_Arac.FirstOrDefault(b => b.AracID == id);
        }
        public List<tbl_Hakkimizda> HakkimizdaSayfa()
        {
            List<tbl_Hakkimizda> HakkimizdaSayfa = db.tbl_Hakkimizda.ToList();
            return HakkimizdaSayfa;
        }
        public class Admin
        {
            [Key]
            public int ID { get; set; }
            public string Kullanici { get; set; }
            public string Sifre { get; set; }
        }

        public List<tbl_Arac> AramaSonuclari(string aracTuru, string marka)
        {
            var query = db.tbl_Arac.Where(arac => arac.Aktifmi == 1);

            if (!string.IsNullOrEmpty(aracTuru))
            {
                query = query.Where(arac => arac.tbl_Aracturu.TipAdi.Contains(aracTuru));
            }

            if (!string.IsNullOrEmpty(marka))
            {
                query = query.Where(arac => arac.tbl_marka.MarkaAdi.Contains(marka));
            }

            List<tbl_Arac> aramaSonuclari = query.ToList();
            return aramaSonuclari;
        }



    }
}