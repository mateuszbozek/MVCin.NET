using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Tekpro.Data;
using Tekpro.Models;

namespace Tekpro.Controllers
{
    public class DiariesController : Controller
    {
        public readonly ApplicationDbContext _db;
        public DiariesController(ApplicationDbContext db)  // dependency injection is here !
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Diary> objEntries = _db.Diaries.ToList();
            return View(objEntries);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Diary obj)
        {
            if (obj != null && obj.Title.Length < 3)
            {
                ModelState.AddModelError("Title", "Title has not enought chars - minimum 3");
            }

            if ( ModelState.IsValid)
            {
                _db.Diaries.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }


            Diary? diary = _db.Diaries.Find(id);

            if (diary == null)
            {
                return NotFound();
            }

            return View(diary);
        }

        [HttpPost]
        public IActionResult Edit(Diary obj)
        {
            if (obj != null && obj.Title.Length < 3)
            {
                ModelState.AddModelError("Title", "Title has not enought chars - minimum 3");
            }

            if (ModelState.IsValid)
            {
                _db.Diaries.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        [HttpGet]
        public IActionResult Destroy(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }


            Diary? diary = _db.Diaries.Find(id);

            if (diary == null)
            {
                return NotFound();
            }

            return View(diary);
        }

        [HttpPost]
        public IActionResult Destroy(Diary obj)
        {
            if (obj != null && obj.Title.Length < 3)
            {
                ModelState.AddModelError("Title", "Title has not enought chars - minimum 3");
            }

            if (ModelState.IsValid)
            {
                _db.Diaries.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
