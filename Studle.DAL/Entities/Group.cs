using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Studle.DAL.Abstractions;

namespace Studle.DAL.Entities
{
    public class Group : AbstractEntity
    {
        [Required]
        [MaxLength(30)]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public int GroupNumber { get; set; }

        [Required]
        public int AdmissionYear { get; set; }

        public List<Subject> Subjects { get; set; } = new ();
    }
}
