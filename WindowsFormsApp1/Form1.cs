using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        double firstNumber = 0;
        double sign = 1;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn1_Clicked(object sender, EventArgs e)
        {
            textBox1.Text += "0";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text += "1";
        }

        private void button02_Click(object sender, EventArgs e)
        {
            textBox1.Text += "2";
        }

        private void button03_Click(object sender, EventArgs e)
        {
            textBox1.Text += "3";
        }

        private void button04_Click(object sender, EventArgs e)
        {
            textBox1.Text += "4";
        }

        private void button05_Click(object sender, EventArgs e)
        {
            textBox1.Text += "5";
        }

        private void button06_Click(object sender, EventArgs e)
        {
            textBox1.Text += "6";
        }

        private void button07_Click(object sender, EventArgs e)
        {
            textBox1.Text += "7";
        }

        private void button08_Click(object sender, EventArgs e)
        {
            textBox1.Text += "8";
        }

        private void button09_Click(object sender, EventArgs e)
        {
            textBox1.Text += "9";
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            firstNumber = double.Parse(textBox1.Text);
            textBox1.Text = "";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            double secondNumber = double.Parse(textBox1.Text);
            double result = firstNumber + secondNumber;
            textBox1.Text = result.ToString();
        }

        private void button12_Click(object sender, EventArgs e)
        {
        

        }
    }
}

      

   
