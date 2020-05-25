using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _25_05_2020
{
    class MainPage: Form
    {
        public LoginPage loginPage;
        private Label labelWelcome = new Label();
        public MainPage() {
            this.InitializeComponent();
            labelWelcome.Text = "This is Main Page";
            this.Controls.Add(labelWelcome);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MainPage
            // 
            this.ClientSize = new System.Drawing.Size(878, 639);
            this.Name = "MainPage";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainPage_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainPage_FormClosed);
            this.ResumeLayout(false);

        }

        private void MainPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("close");
        }

        private void MainPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("close");
            this.loginPage.Enabled = true;
        }
    }
}
