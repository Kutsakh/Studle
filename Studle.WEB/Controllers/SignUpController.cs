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
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(RegisterModel model)
        {
            if (this.ModelState.IsValid)
            {
                var firstname = model.UserName.Split(" ")[0];
                var lastname = model.UserName.Split(" ")[1];
                UserDto user = new UserDto {
                    FirstName = firstname,
                    LastName = lastname,
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
                        return this.Redirect("/Auth/Login");
                    }

                }
                else
                {
                    Log.Warning($"Registration failed {0} ", user);
                }

                return this.Redirect("/Home/Index");
            }

            return this.View();
        }
    }
}
