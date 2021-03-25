using Studle.DAL.Abstractions;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Studle.DAL.Entities

{
    public enum UserType
    {
        Student,
        Teacher,
        Admin,
        Guest
    }

    public class User : AbstractEntity
    {
        [Required]
        [MaxLength(30)]
        [StringLength(255)]
        public string First_name { get; set; }

        [MaxLength(225)]
        public string Middle_name { get; set; }

        [Required]
        [MaxLength(30)]
        [StringLength(255)]
        public string Last_name { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public UserType Role { get; set; }

        public int Semester { get; set; }

        public string Cathedra { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool Open_access { get; set; }
    }
}
