using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.ServiceReference1;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Service1Client serviceClient;
        public Form1()
        {
            serviceClient = new Service1Client();
            InitializeComponent();
            DisplayData();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void DisplayData()
        {
            try
            {
                // Gọi phương thức từ service để lấy danh sách dữ liệu person
                var chatlieus = serviceClient.GetAll();
                // Cập nhật thông tin về tình trạng của mỗi tác phẩm
                
                // Sắp xếp lại danh sách theo thứ tự Id, Name, Age
                var sortedChatLieus = chatlieus.OrderBy(c => c.MaChatLieu)
                                             .ThenBy(c => c.TenChatLieu)
                                             
                                             .ToList();

                // Gán danh sách đã sắp xếp vào DataSource của DataGridView
                dgvChatLieu.DataSource = sortedChatLieus;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy dữ liệu: {ex.Message}");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra giá trị của các ô nhập liệu

                if (txtMaChatLieu.Text == "")
                {

                    MessageBox.Show("Bạn chưa nhập mã chất liệu!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMaChatLieu.Focus();

                }
                else if (txtTenChatLieu.Text == "")
                {

                    MessageBox.Show("Bạn chưa nhập tên chất liệu!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTenChatLieu.Focus();

                }
                
                else
                {
                    
                    
                    ChatLieu t = new ChatLieu()
                    {
                        MaChatLieu = txtMaChatLieu.Text,
                        TenChatLieu = txtTenChatLieu.Text
                        
                    };

                    using (Service1Client service = new Service1Client())
                    {
                        string dupResult = service.CheckDup(t);
                        if (dupResult == "1")
                        {
                            MessageBox.Show("Mã chất liệu đã tồn tại!!Hãy nhập lại.");
                        }
                        else if (service.InsertChatLieu(t) == 1)
                        {
                            MessageBox.Show("Thêm thành công");
                            DisplayData();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }

        private void dgvChatLieu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy thông tin của dòng được chọn
                DataGridViewRow row = dgvChatLieu.Rows[e.RowIndex];

                // Lấy dữ liệu từ các ô trong dòng được chọn
                string chatlieuMaChatLieu = row.Cells["MaChatLieu"].Value != null ? row.Cells["MaChatLieu"].Value.ToString() : "";
                string chatlieuTenChatLieu = row.Cells["TenChatLieu"].Value != null ? row.Cells["TenChatLieu"].Value.ToString() : "";
                


                // Hiển thị thông tin trong các Control
                txtMaChatLieu.Text = chatlieuMaChatLieu;
                txtTenChatLieu.Text = chatlieuTenChatLieu;
                
                txtMaChatLieu.ReadOnly = true;

                // Set giá trị của checkbox dựa trên giới tính


                // Không cần gán giá trị cho cbGioiTinh.Text nữa vì nó sẽ được gán bằng true hoặc false trong dòng trên
                // cbGioiTinh.Text = personGioiTinh;

                // Không cần đặt readonly cho txtid nữa vì dòng này chỉ được gán giá trị mà không có thay đổi nào từ người dùng
                // txtid.ReadOnly = true;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                // Hiển thị hộp thoại hỏi người dùng có muốn sửa dữ liệu không
                string chatlieuMaChatLieu = txtMaChatLieu.Text;

                // Hiển thị thông báo xác nhận
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn sửa thông tin chất liệu có mã: " + txtMaChatLieu.Text + " không?", "Xác nhận sửa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // Kiểm tra giá trị của các ô nhập liệu
                // Xác định tình trạng dựa trên số lượng nhập vào
                if (result == DialogResult.Yes)
                {

                    ChatLieu t = new ChatLieu()
                    {
                        MaChatLieu = txtMaChatLieu.Text,
                        TenChatLieu = txtTenChatLieu.Text
                        
                    };

                    using (Service1Client service = new Service1Client())
                    {
                        if (service.UpdateChatLieu(t) == 1)
                        {
                            MessageBox.Show("Sửa thành công");
                            DisplayData();
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show($"Lỗi khi sửa dữ liệu");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {


                // Hiển thị hộp thoại hỏi người dùng có muốn xóa dữ liệu không
                string chatlieuMaChatLieu = txtMaChatLieu.Text;

                // Hiển thị thông báo xác nhận
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa thông tin chất liệu có mã: " + txtMaChatLieu.Text + " không?", "Xác nhận sửa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // Kiểm tra giá trị của các ô nhập liệu

                // Nếu người dùng chọn Yes
                if (result == DialogResult.Yes)
                {
                    ChatLieu t = new ChatLieu()
                    {
                        MaChatLieu = txtMaChatLieu.Text.ToString()
                    };

                    using (Service1Client service = new Service1Client())
                    {
                        if (service.DelChatLieu(t) == 1)
                        {
                            MessageBox.Show("Xóa thành công");
                            DisplayData();
                        }
                        else
                        {
                            MessageBox.Show("Không thể xóa dữ liệu");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa dữ liệu: {ex.Message}");
            }
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            txtMaChatLieu.Text = "";
            txtTenChatLieu.Text = "";
            txtMaChatLieu.ReadOnly = false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                using (Service1Client service = new Service1Client())
                {
                    string machatlieu = txtMaChatLieu.Text.Trim();
                    string tenchatlieu = txtTenChatLieu.Text.Trim();
                    

                    // Check if either Matacpham or Tentacpham is provided
                    if (!string.IsNullOrEmpty(machatlieu) || !string.IsNullOrEmpty(tenchatlieu) )
                    {
                        ChatLieu c = new ChatLieu()
                        {
                            MaChatLieu = machatlieu,
                            TenChatLieu = tenchatlieu
                            
                        };

                        ChatLieu result = service.GetChatLieu(c);

                        if (result != null)
                        {
                            dgvChatLieu.DataSource = new List<ChatLieu> { result };
                        }
                        else
                        {
                            MessageBox.Show("Không có bản ghi thoả mãn điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập ít nhất một trường thông tin để tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ResetValues()
        {
            txtMaChatLieu.Text = "";
            txtTenChatLieu.Text = "";
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            List<ChatLieu> chatlieuList = new List<ChatLieu>();

            Service1Client service = new Service1Client();
            dgvChatLieu.DataSource = service.GetAll();
            txtMaChatLieu.Text = "";
            txtTenChatLieu.Text = "";
            txtMaChatLieu.ReadOnly = false;
        }
    }
}
