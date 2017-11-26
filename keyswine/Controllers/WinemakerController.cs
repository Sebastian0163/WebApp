using keyswine.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace keyswine.Controllers
{
    public class WinemakerController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Category
        public ActionResult Index()
        {
            return View(db.Winemakers);
        }
        /// <summary>
        /// Вначале добавим в контроллер действие, которые будет получать по Id модель и выводить в представление ее свойства для редактирования
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            Winemaker winemaker = db.Winemakers.Find(id);
            return View(winemaker);

        }
        /// <summary>
        /// сохранение пост запроса
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(Winemaker winemaker)
        {
            db.Entry(winemaker).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Winemaker winemaker)
        {
            db.Entry(winemaker).State = EntityState.Added;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        /// <summary>
        /// удаление модели
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Winemaker b = db.Winemakers.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            return View(b);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Winemaker b = db.Winemakers.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            db.Winemakers.Remove(b);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /// <summary>
        ///    закриття зєднання з бд
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}