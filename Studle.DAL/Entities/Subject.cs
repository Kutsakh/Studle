﻿using Studle.DAL.Abstractions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Studle.DAL.Entities
{
    public enum SubjectType
    {
        exam,
        credit,
        diff_credit
    }

    public class Subject : AbstractEntity
    {
        [Required]
        [MaxLength(30)]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public int DurationSemesters { get; set; }

        [Required]
        public SubjectType Type { get; set; }

        public List<Group> Groups { get; set; } = new List<Group>();
    }
}
