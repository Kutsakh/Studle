using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Serilog;
using Studle.BLL.Dto;
using Studle.BLL.Interfaces;
using Studle.DAL.Entities;
using Studle.DAL.Interfaces;

namespace Studle.BLL.Services
{
    public class UserService : IUserService
    {
        private string[] roles = { "Student", "Teacher", "Admin" };
        private readonly IUnitOfWork unitOfWork;
        IMapper mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IdentityResult> SignUpAsync(UserDto user, string password)
        {
            var userEntity = mapper.Map<User>(user);

            var result = await unitOfWork.UserManager.CreateAsync(userEntity, password);
            Log.Information($"Sign up: {user} ");
            return result;
        }

        public async Task<IdentityResult> AddRole(UserDto user, string role)
        {
            var userEntity = unitOfWork.UserManager.FindByEmailAsync(user.Email);
            if (userEntity == null)
            {
                Log.Warning($"There is no user with email: {0} ", user.Email);
                return null;
            }

            bool roleExists = await unitOfWork.RoleManager.RoleExistsAsync(role);
            if (!roleExists && Array.Exists(roles, element => element == role))
            {
                await unitOfWork.RoleManager.CreateAsync(new Role(role));
            }

            var result = await unitOfWork.UserManager.AddToRoleAsync(userEntity.Result, role);
            return result;
        }

        public async Task<SignInResult> SignInAsync(UserDto user, string password, bool isPersistant)
        {
            var userEntity = unitOfWork.UserManager.FindByEmailAsync(user.Email);
            if (userEntity.Result != null)
            {
                var result = await unitOfWork.SignInManager.PasswordSignInAsync(userEntity.Result, password, isPersistant, false);
                Log.Information($"Signed in: {0} ", user);
                return result;
            }
            Log.Warning($"Email isn`t available: {0} ", user.Email);
            return null;
        }

        public Task<IdentityResult> ChangePasswordAsync(UserDto user, string currentPassword, string newPassword)
        {
            var userEntity = mapper.Map<User>(user);
            return unitOfWork.UserManager.ChangePasswordAsync(userEntity, currentPassword, newPassword);
        }

        public Task SignOutAsync()
        {
            Log.Information("Sign out");
            return unitOfWork.SignInManager.SignOutAsync();
        }
    }
}
