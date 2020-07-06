using System;
using System.Collections.Generic;
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
        public int Mark { get; set; }
        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; }
        public Exam() {
            id++;
            ExamId = id;
        }
    }
}