using Microsoft.AspNetCore.Mvc;
using System;
using StokKartiProjesi.Models;
using System.Diagnostics;
using StokKartiProjesi.Data;
using Microsoft.EntityFrameworkCore;

namespace StokKartiProjesi.Controllers
{
	public class StokController:Controller
	{

		private readonly ApplicationDbContext _context;
		public StokController(ApplicationDbContext context)
		{
			_context = context;
		}
		public IActionResult Index()
			
		{
            List<Stok> result = new List<Stok>();
            result = _context.Stoklar.OrderBy(x => x.StokID).ToList();
            //for(int i = 0; i < stokAdlari.Count; i++)
            //{
            //    int satisToplam1 = _context.Satislar.Where(x => x.IslemTipi == "Satış" && x.Stok.StokAdi == stokAdlari[i]).Select(x => x.Miktar).Sum();
            //    int alisToplam1 = _context.Satislar.Where(x => x.IslemTipi == "Alış" && x.Stok.StokAdi == stokAdlari[i]).Select(x => x.Miktar).Sum();
            //    int toplamHareket1 = (int)(alisToplam1 - satisToplam1);
            //    ViewBag.satisToplam = satisToplam1;
            //    ViewBag.alisToplam = alisToplam1;
            //    ViewBag.toplamHareket = toplamHareket1;
            //}           

            //var anaStokAdet = _context.Stoklar.Where(x => x.StokAdi == "deneme1").Select(x => x.StokAdet);
            //int StokAdet = Convert.ToInt32(anaStokAdet);


            //var Result = _context.Stoklar.ToList();
			return View(result);
		}
		public IActionResult Create()
        {
			return View();
        }

        public IActionResult Edit(string? Id)
        {
            
            var result = _context.Stoklar.Find(Id);
            return View("Create", result);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Stok model)
        {
            

            if (ModelState.IsValid)
            {
                model.StokID = Guid.NewGuid().ToString();
                _context.Stoklar.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Stok model)
        {
           
            if (model != null)
            {
                _context.Stoklar.Update(model);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
        public IActionResult Delete(string? Id)
        {
            var result = _context.Stoklar.Find(Id);
            if (result != null)
            {
                _context.Stoklar.Remove(result);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }



    }
}


