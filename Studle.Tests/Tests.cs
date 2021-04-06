using System;
using Studle.BLL.Interfaces;
using Studle.BLL.Services;
using Studle.BLL.DTO;
using Studle.DAL.Entities;
using Studle.DAL.Interfaces;
using System.Collections.Generic;
using Moq;
using Xunit;
using Studle.Tests.Mocks;
using HashService = Studle.Tests.Mocks.HashService;


namespace Studle.Tests
{
    /*
    public class Tests
    {
        private IUserService userService;
        private IUnitOfWork unitOfWork;
        
              
        public User user = new User()
        {
            Id = 1,
            First_name = "first_name",
            Middle_name = "mid_name",
            Last_name = "last_name",
            Email = "user@gmail.com",
            Password = "test",
            Role = UserType.Student,
            Semester = 2,
            Cathedra = "some_cathdra",
            Open_access = true
        };

        [Fact]
        public void TestSignUp()
        {
            
            unitOfWork = new UnitOfWork();
            unitOfWork.Users.Create(user);
            userService = new UserService(unitOfWork, new HashService());

            UserDTO userDto = userService.SignUp("first_name","last_name","user2@gmail.com","password",UserType.Student);

            Assert.NotNull(userDto);
            Assert.Equal("user2@gmail.com", userDto.Email);
            Assert.True(userDto.Password == "password");

        }
        [Fact]
        public void TestLogin()
        {


            unitOfWork = new UnitOfWork();
            unitOfWork.Users.Create(user);
            userService = new UserService(unitOfWork, new HashService());


            var loggedInUser = userService.Login(user.Email, user.Password);

            Assert.Equal(user.Id, loggedInUser.Id);
            Assert.Equal(user.Email, loggedInUser.Email);
            Assert.Equal(user.First_name, loggedInUser.First_name);           
            Assert.Equal(user.Password, loggedInUser.Password);
        }

        [Fact]
        public void TestGetUser()
        {




            unitOfWork = new UnitOfWork();
            unitOfWork.Users.Create(user);
            userService = new UserService(unitOfWork, new HashService());

            var resUser = userService.GetUser(user.Id);

            Assert.Equal(user.Email, resUser.Email);
            Assert.Equal(user.First_name, resUser.First_name);
            Assert.Equal(user.Last_name, resUser.Last_name);
           
        }

        [Fact]
        public void TestUpdateUser()
        {

            unitOfWork = new UnitOfWork();
            unitOfWork.Users.Create(user);
            userService = new UserService(unitOfWork, new HashService());

            var userDto = new UserDTO
            {
                Id = user.Id,
                First_name = "updated",
                Middle_name = "updated",
                Last_name = "updated",               
                Password = "updated",
                Role = UserType.Student,
                Semester = 2,
                Cathedra = "new_cathdra",
                Open_access = false

            };
            userService.UpdateUser(userDto);
            var resUser = userService.GetUser(userDto.Id);
                
            //Assert.Equal(userDto.Email, resUser.Email);
            Assert.Equal(userDto.First_name, resUser.First_name);
            Assert.Equal(userDto.Last_name, resUser.Last_name);
        }
    }
    */
}
