using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bai01.Models
{
    public class Subject
    {
        private static int id = 0;
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public virtual ICollection<Exam> Exams { get; set; }
        public Subject() {
            this.Exams = new HashSet<Exam>();
            id++;
            SubjectId = id;
        }

    }
}