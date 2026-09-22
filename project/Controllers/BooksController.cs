using Microsoft.AspNetCore.Mvc;
using Tekpro.Data;

namespace Tekpro.Controllers
{
    public class BooksController : Controller
    {
        public readonly ApplicationDbContext _db;

        public BooksController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
