using System;
using Studle.DAL.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace Studle.DAL.Entities

{
    public enum UserRole
    {
        student,
        teacher,
        admin,
        guest
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
