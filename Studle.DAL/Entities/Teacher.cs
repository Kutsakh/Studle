using Studle.DAL.Abstractions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Studle.DAL.Entities
{
    public class Teacher : AbstractEntity
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        [ForeignKey("UserId")]
        public User User { get; set; }

        [Required]
        public int GroupId { get; set; }

        [Required]
        [ForeignKey("GroupId")]
        public Group Group { get; set; }

        [Required]
        public int SubjectId { get; set; }

        [Required]
        [ForeignKey("SubjectId")]
        public Subject Subject { get; set; }
    }
}
