using System;
using System.Collections.Generic;
using Studle.BLL.DTO;
using Studle.DAL.Entities;
using Studle.DAL.Interfaces;
using Studle.BLL.Infrastructure;
using Studle.BLL.Interfaces;
using AutoMapper;
using System.Net.Mail;
using System.Linq;

namespace Studle.BLL.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork Database { get; set; }

        private IHashService HashService;

        public UserDTO CurrentUser { get; private set; }

        public UserService(IUnitOfWork uow, IHashService hashService)
        {
            CurrentUser = null;
            Database = uow;
            this.HashService = hashService;
        }

        public bool IsValidMail(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public UserDTO Login(string email, string password)
        {
            User user = Database.Users.Get().FirstOrDefault(x => x.Email == email);
            if (user == null)
            {
                throw new ArgumentException("There is no such user with this email");
            }

            if ((user.Role == UserType.Student || user.Role == UserType.Teacher) && !user.Open_access)
            {
                throw new ArgumentException("User does not have access to log in");
            }

            UserDTO userDto = new UserDTO
            {
                Id = user.Id,
                First_name = user.First_name,
                Middle_name = user.Middle_name,
                Last_name = user.Last_name,
                Email = user.Email,
                Password = user.Password,
                Role = user.Role,
                Semester = user.Semester,
                Cathedra = user.Cathedra,
                Open_access = user.Open_access
            };

            if (user != null && HashService.GetHash(password) == user.Password)
            {
                CurrentUser = userDto;
            }
            else
            {
                throw new ArgumentException("The email or password is incorrect.");
            }

            return CurrentUser;
        }

        public UserDTO SignUp(string first_name, string last_name, 
                              string email, string password, 
                              UserType role,
                              string middle_name=null, string cathedra=null)
        {
            var existUser = Database.Users.Get().FirstOrDefault(x => x.Email == email);

            if (existUser != null)
            {
                throw new ValidationException("User is already registered", "");
            }

            if (IsValidMail(email))
            {
                User user = new User
                {
                    First_name = first_name,
                    Middle_name = middle_name,
                    Last_name = last_name,
                    Email = email,
                    Password = HashService.GetHash(password),
                    Role = role,
                    Cathedra = cathedra,
                    Open_access = false,
                };
                Database.Users.Update(user);
                Database.Save();
                CurrentUser = new UserDTO
                {
                    Id = user.Id,
                    First_name = user.First_name,
                    Middle_name = user.Middle_name,
                    Last_name = user.Last_name,
                    Email = user.Email,
                    Password = user.Password,
                    Role = user.Role,
                    Semester = user.Semester,
                    Cathedra = user.Cathedra,
                    Open_access = user.Open_access
                };
            }
            else
            {
                throw new ArgumentException("Email is incorrect");
            }

            return CurrentUser;
        }

        public UserDTO GetUser(int? Id)
        {
            if (Id == null)
            {
                throw new ValidationException("User id is not set", "");
            }

            var user = Database.Users.Get(Id.Value);

            if (user == null)
            {
                throw new ValidationException("User is not found", "");
            }
            return new UserDTO {
                First_name = user.First_name,
                Last_name = user.Last_name,
                Email = user.Email,
                Role = user.Role,
                Semester = user.Semester,
                Cathedra = user.Cathedra,
                Open_access = user.Open_access
            };
        }

        public void OpenAccess(int? Id)
        {
            if (Id == null)
            {
                throw new ValidationException("User id is not set", "");
            }

            var user = Database.Users.Get(Id.Value);

            if (user == null)
            {
                throw new ValidationException("User is not found", "");
            }

            user.Open_access = true;
            Database.Users.Update(user);
            Database.Save();
        }

        public void CreateUser(UserDTO userDto)
        {
            if (Database.Users.Get(userDto.Id) != null)
            {
                throw new ValidationException("User already exists", "");
            }
            else
            {
                User user = new User
                {
                    Id = userDto.Id,
                    First_name = userDto.First_name,
                    Middle_name = userDto.Middle_name,
                    Last_name = userDto.Last_name,
                    Email = userDto.Email,
                    Password = HashService.GetHash(userDto.Password),
                    Role = userDto.Role,
                    Semester = userDto.Semester,
                    Cathedra = userDto.Cathedra,
                    Open_access = userDto.Open_access
                };
                Database.Users.Create(user);
                Database.Save();
            }
        }

        public void UpdateUser(UserDTO userDto)
        {


            User user = Database.Users.Get(userDto.Id);

            if (user == null)
            {
                throw new ValidationException("User not found", "");
            }
            else
            {
                HashService Hash = new HashService();

                user.First_name = userDto.First_name;
                user.Middle_name = userDto.Middle_name;
                user.Last_name = userDto.Middle_name;
                user.Cathedra = userDto.Cathedra;
                user.Semester = userDto.Semester;
                user.Password = Hash.GetHash(userDto.Password);

                Database.Users.Update(user);
                Database.Save();
            }
        }

        public void DeleteUser(UserDTO userDto)
        {

            User user = Database.Users.Get(userDto.Id);

            if (user == null)
            {
                throw new ValidationException("User is not found", "");
            }
            else
            {
                Database.Users.Delete(user.Id);
            }

            Database.Save();
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<User>, List<UserDTO>>(Database.Users.GetAll());
        }
    }

}
