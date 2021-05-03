using Microsoft.AspNetCore.Mvc;
using Serilog;
using Studle.BLL.Dto;
using Studle.BLL.Interfaces;
using Studle.WEB.Models;
using System.Threading.Tasks;

namespace Studle.WEB.Controllers
{
    public class SignInController : Controller
    {
        private IUserService userService;

        public SignInController(IUserService service)
        {
            this.userService = service;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<ActionResult> Index(LoginModel model)
        {

            if (this.ModelState.IsValid)
            {
                UserDto user = new UserDto { Email = model.Email };
                var result = await this.userService.SignInAsync(user, model.Password, true);
                if (result?.Succeeded == true)
                {
                    Log.Information($"Logged in: {user.Email} ");
                    return this.Redirect("/Home/Privacy");
                }
                else
                {
                    Log.Warning($"Log in failed {user} ");
                }

                return this.Redirect("/Home/Index");
            }

            return this.View();
        }
    }
}
