using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tekpro.Data;
using Tekpro.Models;

namespace Tekpro.Controllers
{
    public class AuthorsController : Controller
    {
        public readonly ApplicationDbContext _db;

        public AuthorsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Author> authors = _db.Authors.Include(a => a.Books)
                                              .ToList();

            //List<Author> authors = _db.Authors.Where(a => a.Name.Equals("Mari")).ToList();



            return View(authors);
        }
    }
}
