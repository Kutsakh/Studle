using System;
using Studle.DAL.Entities;

namespace Studle.BLL.Dto
{
    public class UserDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public UserRole Role { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
    }
}
