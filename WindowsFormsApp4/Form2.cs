using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form2 : Form
    {
        TextBox myText;
        public Form2()
        {
            InitializeComponent();
        }

        public void SetTextBox(TextBox tb)
        {
            TextBox myText = tb;
        }

        private void button1_Click(object sender, EventArgs e)
        {
         Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            myText.Text = "Form2에서 수정되었음.";
        }

        public void SetMyTextBoxText(string msg)
        {
            textBox1.Text = msg;
        }
    }
}
