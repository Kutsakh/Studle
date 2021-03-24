using Studle.DAL.Abstractions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Required]
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

        [Required]
        public int Semester { get; set; }

        [Required]
        public string Cathedra { get; set; }
    }
}
