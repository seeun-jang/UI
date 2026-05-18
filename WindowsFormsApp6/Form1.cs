using System;
using System.Collections.Generic;
using System.ComponentModel; 
using System.Data;
using System.Drawing;
using System.Linq; 
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        BindingList<Product> cart = new BindingList<Product>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = cart;
            UpdateTotals(); 
        }

        private void UpdateTotals()
        {
            int totalCount = cart.Count;
            int totalPrice = cart.Sum(p => p.Price); 

            textBox1.Text = totalCount.ToString();
            textBox2.Text = totalPrice.ToString();
        }

        
        private void button3_Click(object sender, EventArgs e) 
        {
            cart.Add(new Product { Name = "아메리카노", Price = 3000 });
            UpdateTotals();
        }

        private void button4_Click(object sender, EventArgs e) 
        {
            cart.Add(new Product { Name = "말차라떼", Price = 4500 });
            UpdateTotals();
        }

        private void button5_Click(object sender, EventArgs e) 
        {
            cart.Add(new Product { Name = "자몽에이드", Price = 4500 });
            UpdateTotals();
        }

        private void button6_Click(object sender, EventArgs e) 
        {
            cart.Add(new Product { Name = "티라미수", Price = 5500 });
            UpdateTotals();
        }

        private void button7_Click(object sender, EventArgs e) 
        {
            cart.Add(new Product { Name = "휘낭시에", Price = 2500 });
            UpdateTotals();
        }

        private void button8_Click(object sender, EventArgs e) 
        {
            cart.Add(new Product { Name = "슈크림롤", Price = 5000 });
            UpdateTotals();
        }


        

        private void button2_Click(object sender, EventArgs e) 
        {
          
            if (dataGridView1.CurrentRow != null)
            {
                int selectedIndex = dataGridView1.CurrentRow.Index;
                cart.RemoveAt(selectedIndex);
                UpdateTotals(); 
            }
        }

        private void button1_Click(object sender, EventArgs e) 
        {
      
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void panel2_Paint(object sender, PaintEventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
    }
}


