using System.Collections.Generic;
using Studle.BLL.Dto;
using Studle.DAL.Entities;

namespace Studle.BLL.Interfaces
{
    public interface IUserService
    {
        UserDto CurrentUser { get; }

        UserDto Login(string email, string password);

        // TODO: refactor to use dto
        public UserDto SignUp(
            string firstName,
            string lastName,
            string email,
            string password,
            UserRole role,
            string middleName = null,
            string cathedra = null);

        bool IsValidMail(string emailAddress);

        UserDto GetUser(int? id);

        void CreateUser(UserDto userDto);

        void UpdateUser(UserDto userDto);

        void DeleteUser(UserDto userDto);

        IEnumerable<UserDto> GetUsers();
    }
}
