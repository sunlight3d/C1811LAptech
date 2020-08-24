using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _19_08_2020.Models
{
    public class Album
    {
        private static int _id = 0;
        public int Id { get; set; }
        public String Name { get; set; }
        public String Genre { get; set; }
        public int Year { get; set; }
        public float Price { get; set; }
        public Album():base() {
            _id++;
            Id = _id;
        }
    }
}
