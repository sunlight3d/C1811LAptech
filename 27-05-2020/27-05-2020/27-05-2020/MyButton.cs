using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _27_05_2020
{
    public class MyButton: Button
    {
        public static readonly int WIDTH = 60;
        public static readonly int HEIGHT = 50;
        public static readonly int SPACING = 10;
        public MyButton(): base() {
            this.Width = WIDTH;
            this.Height = HEIGHT;
            this.Margin = new Padding(SPACING);
        }
    }
}
