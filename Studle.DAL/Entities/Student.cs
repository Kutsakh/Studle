using Studle.DAL.Abstractions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


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
