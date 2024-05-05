using WCFDemo;
namespace Tungnt.Net.WinFormApp
{
    public partial class gridStudent : Form
    {


        public gridStudent()
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

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gridStudent_Load(object sender, EventArgs e)
        {

        }

        private void toolNew_Click(object sender, EventArgs e)
        {
            try
            {
                //Create a new student for demo purpose only
                txtStudentID.Text = txtStudentName.Text = txtClass.Text = txtProfessional.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        private void Save_Click(object sender, EventArgs e)
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
    }
    }
}
