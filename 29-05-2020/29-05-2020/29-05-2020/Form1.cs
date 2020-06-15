using _29_05_2020.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _29_05_2020
{
    public partial class CustomerForm : Form
    {
        private Customer selectedCustomer;
        public CustomerForm()
        {
            InitializeComponent();
            comboBoxCustomer.DataSource = Customer.customers;
            if (Customer.customers.Count > 0) {
                this.selectedCustomer = Customer.customers[0];
                this.fillData();
            }
            
            comboBoxCustomer.DisplayMember = "FullName";
            comboBoxCustomer.SelectedIndexChanged += ComboBoxCustomer_SelectedIndexChanged;
        }

        private void ComboBoxCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedCustomer = comboBoxCustomer.SelectedItem as Customer;
            this.fillData();
        }
        private void fillData()
        {
            if(selectedCustomer == null)
            {
                return;
            }
            textBoxFirstName.Text = selectedCustomer.FirstName;
            textBoxLastName.Text = selectedCustomer.LastName;
        }        
    }
}
