using Microsoft.AspNetCore.Mvc;
using Tekpro.Data;
using Tekpro.Models;

namespace Tekpro.Controllers
{
    public class SportsController : Controller
    {
        public readonly ApplicationDbContext _db;

        public SportsController(ApplicationDbContext db) 
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Sport> sports = _db.Sports.ToList();
            return View(sports);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Sport sport)
        {
            if (ModelState.IsValid)
            {
                _db.Sports.Add(sport);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sport);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var sport = _db.Sports.Find(id);

            if (sport == null)
            {
                return NotFound();
            }
            _db.Sports.Remove(sport);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var obj = _db.Sports.Find(id);
            return View(obj);
        }

        [HttpPost]
        public IActionResult Edit(Sport obj)
        {
            if (obj == null)
            {
                return View(obj);
            }

            _db.Sports.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
