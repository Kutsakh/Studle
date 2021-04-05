using Microsoft.AspNetCore.Mvc;

namespace Studle.WEB.Controllers
{
    public class SignUpController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}