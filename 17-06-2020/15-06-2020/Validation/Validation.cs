using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _15_06_2020.Validation
{
    public class Validation
    {
        public static Boolean IsValidTelephone(string telephone)
        {
            Regex regex = new Regex(@"^0[\d]{5,}$");
            return regex.IsMatch(telephone);
        }
    }
}
