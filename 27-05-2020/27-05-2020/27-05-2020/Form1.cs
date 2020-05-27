using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _27_05_2020
{
    public partial class Form1 : Form
    {

        private TextBox txtCalculation = new TextBox();
        public Form1()
        {
            InitializeComponent();
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.setupButtons();
        }
        private List<MyButton> myButtons = new List<MyButton>();
        private List<List<String>> contents = new List<List<String>>();
        private void setupButtons() {
            contents.Add(new List<String>()
            {
                "mc", "m+", "m-", "mr"
            });
            
            contents.Add(new List<String>()
            {
                "7", "8", "9", "/"
            });
            contents.Add(new List<String>()
            {
                "4", "5", "6", "*"
            });
            contents.Add(new List<String>()
            {
                "1", "2", "3", "-"
            });
            contents.Add(new List<String>()
            {
                "0", ".", "-", "+"
            });
            txtCalculation.Location = new Point(MyButton.SPACING, 0);
            txtCalculation.Width = this.contents[0].Count() * (MyButton.WIDTH + MyButton.SPACING) - MyButton.SPACING;
            txtCalculation.Height = MyButton.HEIGHT;
            int startX = MyButton.SPACING;
            int startY = MyButton.SPACING + txtCalculation.Height;
            this.Controls.Add(txtCalculation);
            contents.ForEach(eachContent =>
            {
                eachContent.ForEach(content =>
                {
                    MyButton myButton = new MyButton()
                    {
                        Text = content,
                        Location = new Point(startX, startY)
                    };
                    startX += myButton.Width + MyButton.SPACING;
                    
                    myButton.Click += MyButton_Click;
                    this.myButtons.Add(myButton);//cho dep
                    this.Controls.Add(myButton);
                });
                startX = MyButton.SPACING;
                startY += MyButton.HEIGHT + MyButton.SPACING;
            });
 
            //this.Width = SPACING + this.contents[0].Count() * (MyButton.WIDTH +SPACING);
            //this.Height = SPACING + this.contents.Count() * (MyButton.HEIGHT + SPACING);
            
        }
        private void MyButton_Click(object sender, EventArgs e)
        {
            MyButton myButton = sender as MyButton;               
            Console.WriteLine("haha");
        }
    }
}
