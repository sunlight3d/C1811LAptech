using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _25_05_2020
{
    //decorator pattern 
    public partial class LoginPage : Form
    {
        //business code here .
        private MainPage mainPage = new MainPage();
        public LoginPage()
        {
            InitializeComponent();
            Label label1 = new Label() { 
                Text = "haha",
            };
            Label label2 = new Label()
            {
                Text = "hehe"
            };
            label2.Location = new Point(20, 20);
            this.Controls.Add(label1);
            this.Controls.Add(label2);
            label2.Click += Label2_Click;
        }

        private void Label2_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Toi day ne3");
            try
            {
                this.Enabled = false;
                mainPage.Show();
                mainPage.loginPage = this;
            }
            catch (ObjectDisposedException ex)
            {
                
                mainPage = new MainPage();
                mainPage.loginPage = this;
                mainPage.ShowDialog();
            }
            
        }
    }
}
