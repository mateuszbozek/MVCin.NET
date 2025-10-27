using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics.Eventing.Reader;
using Tekpro.Data;
using Tekpro.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace Tekpro.Controllers
{
    public class ClubsController : Controller
    {
        public readonly ApplicationDbContext _db;

        public ClubsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index(String SearchString = "")
        {
            IQueryable<Club> query = _db.Clubs.Include(c => c.Sport).Include(c => c.Players);

            if (!SearchString.IsNullOrEmpty())
            {
                query = query.Where(c => c.Sport.Name == SearchString );
            }

            List<Club> clubs = query.ToList();
            return View(clubs);

            //List<Club> clubs = _db.Clubs
            //    .Include(c => c.Sport)
            //    .Where(Sport => Sport.Name == "Piłka nożna")    
            //    .ToList();
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
