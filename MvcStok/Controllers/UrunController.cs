using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcStok.Models2;


namespace MvcStok.Controllers
{
    public class UrunController : Controller
    {
        MvcDbStokContext db = new MvcDbStokContext();
        public IActionResult Index()
        {
            var degerler = db.Tblurunlers
                .AsNoTracking()
                .Include(x=> x.UrunkategoriNavigation)
                .Select(x => new TblurunlerDto
                {
                    Fiyat = x.Fiyat,
                    Kategoriad = x.UrunkategoriNavigation.Kategoriad ?? "Kategori Eklenmedi",
                    Marka = x.Marka,
                    Stok = x.Stok,
                    Urunad = x.Urunad,
                    Urunid = x.Urunid
                })
                .ToList();
            return View(degerler);
        }
        [HttpGet]
        public IActionResult YeniUrun() 
        {
            List<SelectListItem> degerler = (from i in db.Tblkategorilers.ToList()
                                             
                                             select new SelectListItem 
                                             {
                                                 Text = i.Kategoriad,
                                                 Value = i.Kategoriid.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public IActionResult YeniUrun(Tblurunler p1) 
        {
            var ktg = db.Tblkategorilers.Where(m=>m.Kategoriid == p1.Urunkategori).FirstOrDefault();
            db.Tblurunlers.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id) 
        {
            var urun = db.Tblurunlers.Find(id);
            db.Tblurunlers.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id) 
        {
            var urun = db.Tblurunlers.Find(id);
            List<SelectListItem> degerler = (from i in db.Tblkategorilers.ToList()

                                             select new SelectListItem
                                             {
                                                 Text = i.Kategoriad,
                                                 Value = i.Kategoriid.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View("UrunGetir",urun);
        }
        public ActionResult Guncelle(Tblurunler p1) 
        {
            var urun = db.Tblurunlers.Find(p1.Urunid);
            urun.Urunad = p1.Urunad;
            urun.Marka = p1.Marka;
            //urun.Urunkategori = p1.Urunkategori;
            urun.Fiyat = p1.Fiyat;
            urun.Stok = p1.Stok;
            var ktg = db.Tblkategorilers.Where(m => m.Kategoriid == p1.Urunkategori).FirstOrDefault();
            urun.Urunkategori = ktg.Kategoriid;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
