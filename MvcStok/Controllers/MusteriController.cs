using Microsoft.AspNetCore.Mvc;
using MvcStok.Models2;

namespace MvcStok.Controllers
{
    public class MusteriController : Controller
    {
        MvcDbStokContext db = new MvcDbStokContext();
        public IActionResult Index()
        {
            var degerler = db.Tblmusteriler2s.ToList();
            return View(degerler);
        }
        [HttpGet]
        public IActionResult YeniMusteri() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult YeniMusteri(Tblmusteriler2Dto p1) 
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.Tblmusteriler2s.Add(new() {
            Musteriad = p1.Musteriad,
            Musterisoyad = p1.Musterisoyad,
            });
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id) 
        {
            var musteri = db.Tblmusteriler2s.Find(id);
            db.Tblmusteriler2s.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGetir(int id) 
        {
            var mstri = db.Tblmusteriler2s.Find(id);
            return View("MusteriGetir",mstri);
        }
        public ActionResult Guncelle(Tblmusteriler2 p1) 
        {
            var mstri = db.Tblmusteriler2s.Find(p1.Musteriid);
            mstri.Musteriad = p1.Musteriad;
            mstri.Musterisoyad = p1.Musterisoyad;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
