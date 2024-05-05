using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormWcfCSDL.ServiceReference1;


namespace WindowsFormWcfCSDL
{
    public partial class Form1 : Form
    {
        private Service1Client serviceClient;
        public Form1()
        {
            InitializeComponent();
            serviceClient = new Service1Client();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Person p = new Person()
                {
                    Id = Convert.ToInt32(txtid.Text),
                    Name = txtten.Text,
                    Age = Convert.ToInt32(txttuoi.Text)
                };

                using (Service1Client service = new Service1Client())
                {
                    if (service.InsertPerson(p) == 1)
                    {
                        MessageBox.Show("Thêm thành công");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm dữ liệu: {ex.Message}");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Person p = new Person()
                {
                    Id = Convert.ToInt32(txtid.Text),
                    Name = txtten.Text,
                    Age = Convert.ToInt32(txttuoi.Text)
                };

                using (Service1Client service = new Service1Client())
                {
                    if (service.UpdatePerson(p) == 1)
                    {
                        MessageBox.Show("Sửa thành công");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sửa dữ liệu: {ex.Message}");
            }

        }
    }
}
