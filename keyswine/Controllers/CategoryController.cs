using keyswine.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace keyswine.Controllers
{
    public class CategoryController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Category
        public ActionResult Index()
        {
            return View(db.Categorys);
        }
        // GET: Category
        public ActionResult Admin()
        {
            return View(db.Categorys);
        }
        /// <summary>
        /// Вначале добавим в контроллер действие, которые будет получать по Id модель и выводить в представление ее свойства для редактирования
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(int? id)
        {            
            Category category = db.Categorys.Find(id);
            return View(category);
            
        }
        /// <summary>
        /// сохранение пост запроса
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            db.Entry(category).State = EntityState.Modified;
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
        public ActionResult Create(Category category)
        {
            db.Entry(category).State = EntityState.Added;
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
            Category b = db.Categorys.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            return View(b);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Category b = db.Categorys.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            db.Categorys.Remove(b);
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