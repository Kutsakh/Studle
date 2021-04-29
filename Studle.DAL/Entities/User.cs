using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
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

    public class User : IdentityUser<int>
    {
        [Required]
        public DateTimeOffset CreatedAt { get; set; }

    }
}
