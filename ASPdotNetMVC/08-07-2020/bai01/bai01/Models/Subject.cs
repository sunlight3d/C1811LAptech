using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace bai01.Models
{
    public class Subject
    {
        private static int id = 0;
        public int SubjectId { get; set; }

        [StringLength(150, MinimumLength = 2,
        ErrorMessage = "Subject's name must between 2 AND 150")]
        [Required]
        public string SubjectName { get; set; }
        public virtual ICollection<Exam> Exams { get; set; }
        public Subject() {
            this.Exams = new HashSet<Exam>();
            id++;
            SubjectId = id;
        }

    }
}