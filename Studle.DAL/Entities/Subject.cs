using Studle.DAL.Abstractions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Studle.DAL.Entities
{
    public enum SubjectType
    {
        Exam,
        Credit,
        DiffCredit
    }

    class Subject : AbstractEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Semester { get; set; }

        [Required]
        public string Faculty { get; set; }

        [Required]
        public float Hours { get; set; }

        [Required]
        public int Teacher_id { get; set; }

        [Required]
        [ForeignKey("Teacher_id")]
        public User Teacher { get; set; }

        [Required]
        public SubjectType Type { get; set; }
    }
}
