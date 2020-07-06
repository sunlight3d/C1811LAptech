using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bai01.Models
{
    public class Student
    {
        private static int id = 0;
        
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public DateTime StudentDOB { get; set; }
        public string StudentClass { get; set; }
        public ICollection<Exam> Exams { get; set; }
        public Student() {
            this.Exams = new HashSet<Exam>();
            id++;
            StudentId = id;
        }

    }
}