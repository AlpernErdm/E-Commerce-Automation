using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        Context c = new Context();  
        public ActionResult Index()
        {
            
            var degerler = c.SatisHarekets.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            List<SelectListItem> deger1 = (from x in c.Uruns.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UrunAd,
                                               Value = x.UrunId.ToString()

                                           }).ToList();
            List<SelectListItem> deger2 = (from x in c.Carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd +" "+  x.CariSoyad,
                                               Value = x.Cariid.ToString()

                                           }).ToList();
            List<SelectListItem> deger3 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd +" "+ x.PersonelSoyad,
                                               Value = x.PersonelId.ToString()

                                           }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
                return View();

        }
        [HttpPost]
        public ActionResult YeniSatis(SatisHareket s)
        {
            s.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SatisHarekets.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult SatisGetir(int id)
        {
            var satis = c.SatisHarekets.Find(id);

            List<SelectListItem> urunler = (from x in c.Uruns.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.UrunAd,
                                                Value = x.UrunId.ToString()
                                            }).ToList();
            List<SelectListItem> cariler = (from x in c.Carilers.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.CariAd + " " + x.CariSoyad,
                                                Value = x.Cariid.ToString()
                                            }).ToList();
            List<SelectListItem> personeller = (from x in c.Personels.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.PersonelAd + " " + x.PersonelSoyad,
                                                    Value = x.PersonelId.ToString()
                                                }).ToList();
            ViewBag.urun = urunler;
            ViewBag.cari = cariler;
            ViewBag.personel = personeller;


            return View("SatisGetir", satis);
        }
        public ActionResult SatisGuncelle(SatisHareket s)
        {
            var sts = c.SatisHarekets.Find(s.Satisİd);

            sts.Cariid = s.Cariid;
            sts.Personelid = s.Personelid;
            sts.Urunid = s.Urunid;
            sts.Adet = s.Adet;
            sts.Fiyat = s.Fiyat;
            sts.ToplamTutar = s.ToplamTutar;

            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SatisDetay(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.Satisİd == id).ToList();
            return View(degerler);
        }

        public ActionResult SatisListesi()
        {
            var satislar = c.SatisHarekets.ToList();
            return View(satislar);
        }
    }
}
