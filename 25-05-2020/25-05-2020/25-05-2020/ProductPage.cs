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
    public partial class ProductPage : Form
    {
        private List<Product> products = new List<Product>(); 
        public ProductPage()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Product newProduct = new Product()
            {
                ProductName = txtProductName.Text,
                YearOfProduction = Int32.Parse(txtYearOfProduction.Text)
            };
            this.products.Add(newProduct);
            this.products.ForEach(product =>
            {
                MessageBox.Show(product.ToString());
            });
        }
    }
}
