using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StokKartiProjesi.Data;
using StokKartiProjesi.Models;

namespace StokKartiProjesi.Controllers
{
    public class SatislarController : Controller
    {

        private readonly ApplicationDbContext _context;

        public SatislarController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Satis> result = new List<Satis>();
            result = _context.Satislar.Include(x => x.Stok)
               .OrderBy(x => x.StokID).ToList();
            
            return View(result);
        }

        public IActionResult Create()
        {
            

            List<Stok> li = new List<Stok>();
            li = _context.Stoklar.ToList();
            ViewBag.listofitems = li;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Satis model)
        {
            

            //var StokIDList = (from Stok in _context.Stoklar select new SelectListItem()
            //{
            //    Text = Stok.StokAdi,
            //    Value = Stok.StokID.ToString(),
            //}).ToList();

            ////StokIDList.Insert(0, SelectListItem(){
            ////    Text = "Seç",
            ////    Value = string.Empty
            ////}).ToList();

            //ViewBag.StokIDList = StokIDList;

            //string toplamFiyat = _context.Satislar.Include(x => x.Miktar * x.BirimFiyatı).ToString();
            //ViewBag.ToplamFiyat = toplamFiyat;

         

            if (ModelState.IsValid)
            {
                
                _context.Satislar.Add(model);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            //List<Stok> li = new List<Stok>();
            //li = _context.Stoklar.ToList();
            //ViewBag.listofitems = li;
            return View();
        }
    }
}
