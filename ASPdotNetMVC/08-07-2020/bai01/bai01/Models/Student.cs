using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace bai01.Models
{
    public class Student
    {
        private static int id = 0;
        
        public int StudentId { get; set; }

        [StringLength(150, MinimumLength = 2,
        ErrorMessage = "Student name must between 2 AND 150")]
        [Required]
        public string StudentName { get; set; }

        [DataType(DataType.DateTime)]
        [Required]
        public DateTime StudentDOB { get; set; }
        [Required]
        public string StudentClass { get; set; }
        public ICollection<Exam> Exams { get; set; }
        public Student() {
            this.Exams = new HashSet<Exam>();
            id++;
            StudentId = id;
        }

    }
}