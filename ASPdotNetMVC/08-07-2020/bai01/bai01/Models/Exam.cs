using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace bai01.Models
{
    public class Exam
    {
        private static int id = 0;
        public int ExamId { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }

        [Range(0, 100, ErrorMessage = "MArk must be 0-> 100")]        
        [Required]
        public int Mark { get; set; }
        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; }
        public Exam() {
            id++;
            ExamId = id;
        }
    }
}