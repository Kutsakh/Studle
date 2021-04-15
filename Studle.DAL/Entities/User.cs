using System;
using System.ComponentModel.DataAnnotations;
using Studle.DAL.Abstractions;

namespace Studle.DAL.Entities

{
    public enum UserRole
    {
        Student,
        Teacher,
        Admin,
        Guest,
    }

    public class User : AbstractEntity
    {
        [Required]
        [MaxLength(30)]
        [StringLength(255)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        [StringLength(255)]
        public string LastName { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        public string Password { get; set; }

        [Required]
        public UserRole Role { get; set; }

        [Required]
        public DateTimeOffset CreatedAt { get; set; }
    }
}
