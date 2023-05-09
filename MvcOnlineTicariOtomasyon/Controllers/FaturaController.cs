using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;


namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura
        Context c = new Context();
        public ActionResult Index()
        {
            var liste = c.Faturalars.ToList();
            return View(liste);
        }
         [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FaturaEkle(Faturalar f)
        {
            c.Faturalars.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaGetir(int id)
        {
            var fatura = c.Faturalars.Find(id);
            return View("FaturaGetir", fatura);
        }

        public ActionResult FaturaGuncelle(Faturalar f)
        {
            var fatura = c.Faturalars.Find(f.Faturaİd);

            fatura.FaturaSeriNo = f.FaturaSeriNo;
            fatura.FaturaSıraNo = f.FaturaSıraNo;
            fatura.Tarih = f.Tarih;
            fatura.VergiDairesi = f.VergiDairesi;
            fatura.Saat= f.Saat;
            fatura.TeslimAlan= f.TeslimAlan;
            fatura.TeslimEden= f.TeslimEden;
          
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaListesi()
        {
            var faturalar = c.Faturalars.ToList();
            return View(faturalar);
        }

        public ActionResult FaturaDetay(int id)
        {
            var kalemler = c.FaturaKalems.Where(x => x.Faturaid == id).ToList();

            return View(kalemler);

        }

        [HttpGet]
        public ActionResult YeniKalem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKalem(FaturaKalem f)
        {
            c.FaturaKalems.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}
