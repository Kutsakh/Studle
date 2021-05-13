using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Studle.DAL.Abstractions;

namespace Studle.DAL.Entities
{
    public class Student : AbstractEntity
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        [ForeignKey("UserId")]
        public User User { get; set; }

        public int GroupId { get; set; }

        [ForeignKey("GroupId")]
        public Group Group { get; set; }
    }
}
