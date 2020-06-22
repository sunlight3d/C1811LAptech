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

namespace _15_06_2020
{
    public partial class EmployeeList : Form
    {
        public EmployeeList()
        {
            InitializeComponent();
            List<Department> foundDepartments = Database.SharedInstance().getAllDepartments();
            Console.WriteLine("haha");
            foundDepartments.ForEach(department => {
                this.treeViewDepartment.Nodes.Add(department.DeptName);
            });
            this.treeViewDepartment.NodeMouseClick += TreeViewDepartment_NodeMouseClick;
            treeViewDepartment.SelectedNode = this.treeViewDepartment.Nodes[0];
            this.TreeViewDepartment_NodeMouseClick(treeViewDepartment,
                new TreeNodeMouseClickEventArgs(treeViewDepartment.SelectedNode, new MouseButtons(), 0, 0, 0));
        }

        private void TreeViewDepartment_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string selectedDepartmentName = e.Node.Text;
            Department selectedDepartment = Database.SharedInstance()
                        .getDepartmentFromName(selectedDepartmentName);
            int departmentId = selectedDepartment.DeptId;
            List<Employee> foundEmployees = Database.SharedInstance().getAllEmployees(departmentId);
            this.gridViewEmployee.DataSource = foundEmployees;
        }

        private void employeesProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeDetail employeeDetail = new EmployeeDetail();
            if (this.gridViewEmployee.SelectedRows.Count > 0)
            {
                var selectedRow = this.gridViewEmployee.SelectedRows[0];
                //convert selectedRow => selectedEmployeeE
                var selectedEmployee = selectedRow.DataBoundItem as Employee;
                employeeDetail = new EmployeeDetail();
                employeeDetail.SelectedEmployee = selectedEmployee;//set Data => UI tuong ung thay doi
                employeeDetail.Show();

            }
            else
            {
                MessageBox.Show("You must select 1 employee");
            }
        }
    }
}
