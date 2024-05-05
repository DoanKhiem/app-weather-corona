using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public bool isExit = true;
        
        public Form3()
        {
            InitializeComponent();
        }
        private bool isForm1Opened = false;
        private void chấtLiệuHàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem Form đã được mở hay chưa
            if (!isForm1Opened)
            {
                Form1 frm1 = new Form1();
                frm1.FormClosed += (s, args) => { isForm1Opened = false; }; // Đặt lại trạng thái khi Form đã đóng
                frm1.Show();
                isForm1Opened = true;
            }
        }
        private bool isForm2Opened = false;
        private void hàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem Form đã được mở hay chưa
            if (!isForm2Opened)
            {
                Form2 frm2 = new Form2();
                frm2.FormClosed += (s, args) => { isForm2Opened = false; }; // Đặt lại trạng thái khi Form đã đóng
                frm2.Show();
                isForm2Opened = true;
            }
        }
        
        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isExit)
                Application.Exit();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isExit)
            {
                if (MessageBox.Show("Bạn có muốn thoát không?", "Cảnh báo", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    e.Cancel = true;
            }
        }
        private bool isForm4Opened = false;
        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem Form đã được mở hay chưa
            if (!isForm4Opened)
            {
                Form4 frm4 = new Form4();
                frm4.FormClosed += (s, args) => { isForm4Opened = false; }; // Đặt lại trạng thái khi Form đã đóng
                frm4.Show();
                isForm4Opened = true;
            }
        }
        private bool isForm5Opened = false;
        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem Form đã được mở hay chưa
            if (!isForm5Opened)
            {
                Form5 frm5 = new Form5();
                frm5.FormClosed += (s, args) => { isForm5Opened = false; }; // Đặt lại trạng thái khi Form đã đóng
                frm5.Show();
                isForm5Opened = true;
            }
        }
        private bool isForm6Opened = false;
        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isForm6Opened)
            {
                Form6 frm6 = new Form6();
                frm6.FormClosed += (s, args) => { isForm6Opened = false; }; // Đặt lại trạng thái khi Form đã đóng
                frm6.Show();
                isForm6Opened = true;
            }
        }
        private bool isForm7Opened = false;
        private void tìmKiếmHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isForm7Opened)
            {
                Form7 frm7 = new Form7();
                frm7.FormClosed += (s, args) => { isForm7Opened = false; }; // Đặt lại trạng thái khi Form đã đóng
                frm7.Show();
                isForm7Opened = true;
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
