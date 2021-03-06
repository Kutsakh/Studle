using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Studle.BLL.Dto;

namespace Studle.BLL.Interfaces
{
    public interface IUserService
    {
        Task<IdentityResult> SignUpAsync(UserDto user, string password);

        public Task<SignInResult> SignInAsync(UserDto user, string password, bool isPersistant);

        Task<IdentityResult> ChangePasswordAsync(UserDto user, string currentPassword, string newPassword);

        Task SignOutAsync();

        public Task<IdentityResult> AddRole(UserDto user, string role);
    }
}
