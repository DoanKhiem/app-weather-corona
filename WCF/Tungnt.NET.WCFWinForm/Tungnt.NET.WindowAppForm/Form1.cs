using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tungnt.NET.WindowAppForm.WCFDemo;

namespace Tungnt.NET.WindowAppForm
{
    public partial class StudentManagerForm : Form
    {
        public StudentManagerForm()
        {
            InitializeComponent();
            try
            {
                WCFDemo.WCFServiceDemoClient client = new WCFDemo.WCFServiceDemoClient();
                gridStudent.DataSource = client.GetStudents();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolNew_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo một sinh viên mới (cho mục đích demo)
                txtStudentID.Text = txtStudentName.Text = txtClass.Text = txtProfessional.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tạo sinh viên mới: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void toolEdit_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow selectedRow = gridStudent.SelectedRows[0];
                if (selectedRow != null)
                {
                    //Manual binding for demo purpose only
                    txtStudentID.Text = selectedRow.Cells["StudentID"].Value.ToString();
                    txtStudentName.Text = selectedRow.Cells["StudentName"].Value.ToString();
                    txtClass.Text = selectedRow.Cells["Class"].Value.ToString();
                    txtProfessional.Text = selectedRow.Cells["Professional"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolDelete_Click(object sender, EventArgs e)
        {
            try
            {
                WCFDemo.WCFServiceDemoClient client = new WCFDemo.WCFServiceDemoClient();
                if (MessageBox.Show("Are you sure you want to delete this student?", "Student Manager", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    int deleteStudentID = int.Parse(gridStudent.SelectedRows[0].Cells["StudentID"].Value.ToString());
                    if (client.DeleteStudent(deleteStudentID))
                    {
                        gridStudent.DataSource = client.GetStudents();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                WCFDemo.WCFServiceDemoClient client = new WCFDemo.WCFServiceDemoClient();
                gridStudent.DataSource = client.GetStudents();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //Check student is new Student or update Student
                bool isNewStudent = true;
                foreach (DataGridViewRow item in gridStudent.Rows)
                {
                    if (item.Cells["StudentID"].Value.ToString() == txtStudentID.Text)
                    {
                        isNewStudent = false;
                        break;
                    }
                }

                WCFDemo.WCFServiceDemoClient client = new WCFDemo.WCFServiceDemoClient();
                Student oStudent = new Student() { StudentID = int.Parse(txtStudentID.Text), StudentName = txtStudentName.Text, Class = txtClass.Text, Professional = txtProfessional.Text };
                if (isNewStudent ? client.AddStudent(oStudent) : client.UpdateStudent(oStudent))
                {
                    gridStudent.DataSource = client.GetStudents();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gridStudent_Click(object sender, EventArgs e)
        {

        }

        private void gridStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem người dùng đã chọn một dòng (Row) hay một ô (Cell)
            if (e.RowIndex >= 0)
            {
                // Lấy thông tin của dòng được chọn
                DataGridViewRow row = gridStudent.Rows[e.RowIndex];

                // Lấy dữ liệu từ các ô trong dòng được chọn
                string studentID = row.Cells["MaSV"].Value.ToString();
                string studentName = row.Cells["TenSV"].Value.ToString();
                string className = row.Cells["Lop"].Value.ToString();
                string professional = row.Cells["Professional"].Value.ToString();

                // Hiển thị thông tin trong các Control (ví dụ: TextBox)
                txtStudentID.Text = studentID;
                txtStudentName.Text = studentName;
                txtClass.Text = className;
                txtProfessional.Text = professional;
            }
        }

        private void gridStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Đặt thông tin về trắng khi click vào DataGridView
            txtStudentID.Text = string.Empty;
            txtStudentName.Text = string.Empty;
            txtClass.Text = string.Empty;
            txtProfessional.Text = string.Empty;
        }

        private void StudentManagerForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                WCFDemo.WCFServiceDemoClient client = new WCFDemo.WCFServiceDemoClient();
                if (MessageBox.Show("Are you sure you want to delete this student?", "Student Manager", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    int deleteStudentID = int.Parse(gridStudent.SelectedRows[0].Cells["StudentID"].Value.ToString());
                    if (client.DeleteStudent(deleteStudentID))
                    {
                        gridStudent.DataSource = client.GetStudents();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow selectedRow = gridStudent.SelectedRows[0];
                if (selectedRow != null)
                {
                    //Manual binding for demo purpose only
                    txtStudentID.Text = selectedRow.Cells["StudentID"].Value.ToString();
                    txtStudentName.Text = selectedRow.Cells["StudentName"].Value.ToString();
                    txtClass.Text = selectedRow.Cells["Class"].Value.ToString();
                    txtProfessional.Text = selectedRow.Cells["Professional"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
