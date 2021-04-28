using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Studle.DAL.Abstractions;

namespace Studle.DAL.Entities
{
    public class Mark : AbstractEntity
    {
        [Required]
        public int Point { get; set; }

        [Required]
        public int TopicId { get; set; }

        [Required]
        [ForeignKey("TopicId")]
        public Topic Topic { get; set; }

        [Required]
        public int StudentId { get; set; }

        [Required]
        [ForeignKey("StudentId")]
        public Student Student { get; set; }

        [Required]
        public int TeacherId { get; set; }

        [Required]
        [ForeignKey("TeacherId")]
        public Teacher Teacher { get; set; }
    }
}
