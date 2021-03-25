using Studle.DAL.Entities;
    

namespace Studle.BLL.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string First_name { get; set; }
        public string Middle_name { get; set; }
        public string Last_name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserType Role { get; set; }
        public int Semester { get; set; }
        public string Cathedra { get; set; }
        public bool Open_access { get; set; }
    }
}