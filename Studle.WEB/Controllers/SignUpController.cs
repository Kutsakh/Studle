using Microsoft.AspNetCore.Mvc;
using Serilog;
using Studle.BLL.Dto;
using Studle.BLL.Interfaces;
using Studle.WEB.Models;
using System;
using System.Threading.Tasks;

namespace Studle.WEB.Controllers
{
    public class SignUpController : Controller
    {

        private IUserService userService;

        public SignUpController(IUserService service)
        {
            this.userService = service;
        }


        [HttpGet]
        public IActionResult Index()
        {
            Log.Information("GET in sign up");
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(RegisterModel model)
        {
            if (this.ModelState.IsValid)
            {
                Log.Information("ModelState valid");
                UserDto user = new UserDto {
                    UserName = model.UserName,
                    Email = model.Email,
                    CreatedAt = DateTimeOffset.Now,
                };
                var result = await this.userService.SignUpAsync(user, model.Password);
                if (result.Succeeded)
                {
                    result = await this.userService.AddRole(user, "Student");
                    if (result.Succeeded)
                    {
                        Log.Verbose($"Registration user {0} ", user);
                        return this.Redirect("/SignIn/Index");
                    }
                }

                Log.Warning($"Registration failed {0} ", user);
                return this.Redirect("/SignUp/Index");
            }

            return this.View();
        }
    }
}
