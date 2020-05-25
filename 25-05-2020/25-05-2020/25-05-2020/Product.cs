using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25_05_2020
{
    class Product: Object
    {
        public String ProductName { get; set; }
        public int YearOfProduction { get; set; }
        public override string ToString() {
            return "name = " + ProductName + ", year = " + YearOfProduction;
        }

    }
}
