using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics.Eventing.Reader;
using Tekpro.Data;
using Tekpro.Models;
using Tekpro.Models.ViewModels;
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

        public IActionResult Index(ClubFilterViewModel filter)
        {
            IQueryable<Club> query = _db.Clubs.Include(c => c.Sport).Include(c => c.Players);

            if (!filter.ClubName.IsNullOrEmpty())
            {
                query = query.Where(c => c.Name == filter.ClubName );
            }
            if (!filter.SportName.IsNullOrEmpty())
            {
                query = query.Where(c => c.Sport.Name == filter.SportName);
            }
            if (!filter.PlayerSurename.IsNullOrEmpty())
            {
                query = query.Where(c => c.Players.Any(p => p.Name == filter.PlayerSurename) );
            }

            filter.Clubs = query.ToList();

            return View(filter);
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
            if (obj.SportId == 0)
            {
                return View(obj);
            }

            _db.Clubs.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Club? club = _db.Clubs.Find(id);
            ViewBag.Sports = new SelectList(_db.Sports.OrderBy(s => s.Name), "Id", "Name");
            return View(club);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Club? club = _db.Clubs.Find(id);
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
