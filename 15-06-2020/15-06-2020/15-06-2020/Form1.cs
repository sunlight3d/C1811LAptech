using _15_06_2020.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _15_06_2020.Validation;
namespace _15_06_2020
{
    public partial class EmployeeDetail : Form, IMyForm
    {
        public void SetupUI()
        {
            this.comboBoxDepartment.DataSource = new List<string>() { "IT", "Administration", "Sales" };
            this.buttonAddNew.Click += ButtonAddNew_Click;
            this.buttonCancel.Click += ButtonCancel_Click;
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            
        }

        private void ButtonAddNew_Click(object sender, EventArgs e)
        {
            var Gender = "";
            if (!this.radioGenderMale.Checked && !this.radioGenderFemale.Checked)
            {
                MessageBox.Show("You must enter gender");
                return;
            }

            if (this.radioGenderFemale.Checked)
            {
                Gender = "Female";
            }
            else if(this.radioGenderMale.Checked)
            {
                Gender = "Male";           
            }
            if (this.dateTimePickerDOB.Value.Year < 2000)
            {
                MessageBox.Show("Year must >= 1999");
                return;
            }

            if (!_15_06_2020.Validation.Validation.IsValidTelephone(txtTelephone.Text))
            {
                MessageBox.Show("phone must be 0...");
                return;
            }
            
            Employee.employees.Add(
                new Employee() { 
                    EmployeeName = this.txtEmployeeName.Text,
                    DateOfBirth = this.dateTimePickerDOB.Value,
                    Telephone = this.txtTelephone.Text,
                    Gender = Gender,
                    Department = comboBoxDepartment.Text
                }
            );
            var x = Employee.employees;
            Console.WriteLine("haha");
        }

        public EmployeeDetail()
        {
            InitializeComponent();
           this.SetupUI();
        }

    }
}
