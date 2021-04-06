using System.Collections.Generic;
using Studle.DAL.Entities;
using Studle.BLL.DTO;


namespace Studle.BLL.Interfaces
{
    public interface IUserService
    {
        UserDTO CurrentUser { get; }
        UserDTO Login(string email, string password);
        public UserDTO SignUp(string first_name, string last_name, 
                              string email, string password,
                              UserRole role,
                              string middle_name = null, string cathedra = null);
        bool IsValidMail(string emailaddress);
        UserDTO GetUser(int? Id);
        void CreateUser(UserDTO userDTO);
        void UpdateUser(UserDTO userDTO);
        void DeleteUser(UserDTO userDTO);
        IEnumerable<UserDTO> GetUsers();
    }
}