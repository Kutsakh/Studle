using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Studle.DAL.Abstractions;

namespace Studle.DAL.Entities
{
    public class Topic : AbstractEntity
    {
        [Required]
        [MaxLength(30)]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public int SubjectId { get; set; }

        [Required]
        [ForeignKey("SubjectId")]
        public Subject Subject { get; set; }
    }
}
