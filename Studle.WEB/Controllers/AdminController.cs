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
    }
}