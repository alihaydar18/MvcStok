using Microsoft.AspNetCore.Mvc;
using MvcStok.Models2;

namespace MvcStok.Controllers
{
    public class KategoriController : Controller
    {
        MvcDbStokContext db = new MvcDbStokContext();
        public IActionResult Index()
        {
            var degerler = db.Tblkategorilers.ToList();
            return View(degerler);
        }

        [HttpGet]
        public IActionResult YeniKategori() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult YeniKategori(Tblkategoriler p1) 
        {
            if (!ModelState.IsValid) 
            {
                return View("YeniKategori");
            }
            db.Tblkategorilers.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(short id) 
        {
            var kategori = db.Tblkategorilers.Find(id);
            db.Tblkategorilers.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(short id) 
        {
            var ktgr = db.Tblkategorilers.Find(id);
            return View("KategoriGetir",ktgr);
        }
        public ActionResult Guncelle(Tblkategoriler p1) 
        {
            var ktgr = db.Tblkategorilers.Find(p1.Kategoriid);
            ktgr.Kategoriad = p1.Kategoriad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
