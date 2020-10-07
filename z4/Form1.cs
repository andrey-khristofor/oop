using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace z4
{
    public partial class Form1 : Form
    {
        Triangle triangle = new Triangle(0, 0, 0);
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            triangle.ChangeSideA(Convert.ToDouble(textBox1.Text));
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            triangle.ChangeSideB(Convert.ToDouble(textBox1.Text));
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            triangle.ChangeSideC(Convert.ToDouble(textBox1.Text));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox4.Text = Convert.ToString(triangle.CalculatePerimeter());
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
