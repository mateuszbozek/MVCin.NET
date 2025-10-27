using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tekpro.Data;
using Tekpro.Models;

namespace Tekpro.Controllers
{
    public class ClubsController : Controller
    {
        public readonly ApplicationDbContext _db;

        public ClubsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            //List<Club> clubs = _db.Clubs
            //    .Include(c => c.Sport)
            //    .Where(Sport => Sport.Name == "Piłka nożna")    
            //    .ToList();

            var correct_clubs = (from c in _db.Clubs.Include(c => c.Sport).Include(c=> c.Players)
                                 where c.Sport.Name == "Piłka nożna"
                                 select c).ToList();

            return View(correct_clubs);
        }

        public IActionResult Create() {
            ViewBag.Sports = new SelectList(_db.Sports.OrderBy(s => s.Name), "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Club obj)
        {
            if (obj == null) {
                return View(obj);
            }

            _db.Clubs.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Club club = _db.Clubs.Find(id);
            ViewBag.Sports = new SelectList(_db.Sports.OrderBy(s => s.Name), "Id", "Name");
            return View(club);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Club club = _db.Clubs.Find(id);
            if (club == null)
            {
                return View();
            }
            _db.Clubs.Remove(club);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
