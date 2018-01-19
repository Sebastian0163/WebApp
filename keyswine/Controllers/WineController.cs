using keyswine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace keyswine.Controllers
{
    public class WineController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
             
        // GET: Wine
        public ActionResult Index()
        {
            var winemakers = db.Wines.Include(p => p.Winemaker).Include(p => p.Category);
            return View(winemakers.ToList());

        }

        // GET: Wine/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Wine/Create

        [HttpGet]
        public ActionResult Create()
        {
            
                SelectList category = new SelectList(db.Categorys, "Id", "Name");
                ViewBag.Categorys = category;
                // Формируем список команд для передачи в представление
                SelectList winemaker = new SelectList(db.Winemakers, "Id", "Name");
                ViewBag.Winemakers = winemaker;
            
            return View();
        }
        // POST: Wine/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "ID,Name,Email,Phone,PurchaseDate")]Wine wine)
        {
            if (ModelState.IsValid)
            {
                //Добавляем игрока в таблицу
                db.Wines.Add(wine);
                db.SaveChanges();
                // перенаправляем на главную страницу
                return RedirectToAction("Index");
            }
            return View(wine);
        }

       

       
        




        // GET: Wine/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Wine/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Wine/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Wine/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
