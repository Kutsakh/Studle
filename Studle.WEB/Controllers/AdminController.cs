using Microsoft.AspNetCore.Mvc;

namespace Studle.WEB.Controllers
{
    public class AdminController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }

        // GET
        public IActionResult Groups()
        {
            return View();
        }

        // GET
        public IActionResult Subjects()
        {
            return View();
        }

        [HttpGet("admin/subjects/{id}")]
        public IActionResult SingleSubject(int id)
        {
            return View();
        }

        [HttpGet("admin/subjects/{id}/edit")]
        public IActionResult EditSubject(int id)
        {
            return View();
        }
    }
}