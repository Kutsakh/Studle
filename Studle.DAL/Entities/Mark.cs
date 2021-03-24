using System;
using Studle.DAL.Abstractions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Studle.DAL.Entities
{
    public class Mark : AbstractEntity
    {
        [Required]
        public float Point { get; set; }

        [Required]
        public DateTimeOffset Date { get; set; }

        [Required]
        public int Student_id { get; set; }

        [Required]
        [ForeignKey("Student_id")]
        public User Student { get; set; }

        [Required]
        public int Subject_id { get; set; }

        [Required]
        [ForeignKey("Subject_id")]
        public Subject Subject { get; set; }
    }

}