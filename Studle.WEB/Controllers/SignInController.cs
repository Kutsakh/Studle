using Microsoft.AspNetCore.Mvc;

namespace Studle.WEB.Controllers
{
    public class SignInController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}