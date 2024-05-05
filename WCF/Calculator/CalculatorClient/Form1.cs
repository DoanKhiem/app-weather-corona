using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorClient
{
    public partial class Form1 : Form
    {
        private CalculatorServiceReference.Service1Client client;
        public Form1()
        {
            InitializeComponent();
            client = new CalculatorServiceReference.Service1Client();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double x = Convert.ToDouble(textBox1.Text);
            double y = Convert.ToDouble(textBox2.Text);
            double result = client.Add(x, y);
            labelResult.Text = "Kết quả: " + result.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double x = Convert.ToDouble(textBox1.Text);
            double y = Convert.ToDouble(textBox2.Text);
            double result = client.Subtract(x, y);
            labelResult.Text = "Kết quả: " + result.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double x = Convert.ToDouble(textBox1.Text);
            double y = Convert.ToDouble(textBox2.Text);
            double result = client.Multiply(x, y);
            labelResult.Text = "Kết quả: " + result.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double x = Convert.ToDouble(textBox1.Text);
            double y = Convert.ToDouble(textBox2.Text);
            try
            {
                double result = client.Divide(x, y);
                labelResult.Text = "kết quả: " + result.ToString();
            }
            catch (Exception ex)
            {
                labelResult.Text = "Lỗi: " + ex.Message;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
