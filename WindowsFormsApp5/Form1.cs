using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ProductSource.Add(new Product { Name = "감자", Price = 3000 });
            ProductSource.Add(new Product { Name = "고구마", Price = 4000 });
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            string name = tbProductName.Text;
            int price = int.Parse(tbProductPrice.Text);
            ProductSource.Add(new Product { Name = name, Price = price });
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int index = dataGridView1.CurrentRow.Index;
            Product item = dataGridView1.Rows[index].DataBoundItem as Product;

            DialogResult result = MessageBox.Show(item.Name + "을 삭제 하시겠습니까?", "경고", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {

                dataGridView1.Rows.RemoveAt(index);
            }

        }
    }
}
