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
            using (C1811LEntities db = new C1811LEntities())
            {
                List<tblDepartment> foundDepartments = 
                    db.tblDepartments.ToList();
                Console.WriteLine("haha");

                foundDepartments.ForEach(department => {
                    this.treeViewDepartment.Nodes.Add(department.DeptName);
                });     
                this.treeViewDepartment.NodeMouseClick += TreeViewDepartment_NodeMouseClick;
                treeViewDepartment.SelectedNode = this.treeViewDepartment.Nodes[0];
                this.TreeViewDepartment_NodeMouseClick(treeViewDepartment,
                    new TreeNodeMouseClickEventArgs(treeViewDepartment.SelectedNode, new MouseButtons(), 0,0,0));
            }
        }

        private void TreeViewDepartment_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string selectedDepartmentName = e.Node.Text;
            
            using (C1811LEntities db = new C1811LEntities())
            {
                int departmentId = db.tblDepartments
                    .Where(department => department.DeptName.Equals(selectedDepartmentName))
                    .FirstOrDefault().DeptID;
                List<tblEmployee> foundEmployees = db.tblEmployees
                    .Where(employee => employee.DeptId == departmentId)
                    .ToList();
                this.gridViewEmployee.DataSource = foundEmployees;
 
            }
        }
        
    }
}
