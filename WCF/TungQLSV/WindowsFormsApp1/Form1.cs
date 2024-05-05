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
        private Service1Client _client = new Service1Client();
        private List<SinhVien> _danhSachSinhVien = new List<SinhVien>();
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DateTime ngaySinh = dateTimePickerNgaySinh.Value;
            // Thêm dữ liệu mẫu
            _danhSachSinhVien.Add(new SinhVien { MaSV = "SV01", TenSV = "Nguyễn Văn A", NgaySinh = ngaySinh, Lop = "DH10C1", Diem = 8 });
            _danhSachSinhVien.Add(new SinhVien { MaSV = "SV02", TenSV = "Trần Thị B", NgaySinh = ngaySinh, Lop = "DH10C1", Diem = 4 });
            // Xác định xếp loại cho từng sinh viên
            foreach (var sv in _danhSachSinhVien)
            {
                sv.XepLoai = (sv.Diem > 5) ? "Đỗ" : "Trượt";
            }

            // Hiển thị dữ liệu lên DataGridView
            dataGridViewSinhVien.DataSource = _danhSachSinhVien;
            
        }
        public class SinhVien
        {
            public string MaSV { get; set; }
            public string TenSV { get; set; }
            public DateTime NgaySinh { get; set; } // Thay đổi kiểu dữ liệu của NgaySinh từ string sang DateTime
            public string Lop { get; set; }
            public float Diem { get; set; }
            public string XepLoai { get; set; }
        }

        private void dataGridViewSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem người dùng đã nhấp vào một ô dữ liệu hợp lệ không
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Lấy thông tin của sinh viên từ hàng được chọn
                SinhVien selectedSV = (SinhVien)dataGridViewSinhVien.Rows[e.RowIndex].DataBoundItem;

                // Hiển thị thông tin của sinh viên trong các control khác
                txtMaSV.Text = selectedSV.MaSV;
                txtTenSV.Text = selectedSV.TenSV;
                dateTimePickerNgaySinh.Value = selectedSV.NgaySinh;
                txtLop.Text = selectedSV.Lop;
                txtDiem.Text = selectedSV.Diem.ToString();
                textBox5.Text = selectedSV.XepLoai;
            }


        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ các control
            string maSV = txtMaSV.Text;
            string tenSV = txtTenSV.Text;
            DateTime ngaySinh;
            if (!DateTime.TryParse(dateTimePickerNgaySinh.Text, out ngaySinh))
            {
                MessageBox.Show("Ngày sinh không hợp lệ.");
                return;
            }
            string lop = txtLop.Text;
            float diem;
            if (!float.TryParse(txtDiem.Text, out diem))
            {
                MessageBox.Show("Điểm không hợp lệ.");
                return;
            }

            // Xác định xếp loại
            string xepLoai = (diem > 5) ? "Đỗ" : "Trượt";

            // Tạo đối tượng SinhVien mới
            SinhVien sinhVienMoi = new SinhVien
            {
                MaSV = maSV,
                TenSV = tenSV,
                NgaySinh = ngaySinh,
                Lop = lop,
                Diem = diem,
                XepLoai = xepLoai // Thêm thông tin xếp loại vào đối tượng SinhVien
            };

            // Thêm sinh viên vào danh sách
            _danhSachSinhVien.Add(sinhVienMoi);

            // Cập nhật lại DataSource của DataGridView
            dataGridViewSinhVien.DataSource = null;
            dataGridViewSinhVien.DataSource = _danhSachSinhVien;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có hàng nào được chọn không
            if (dataGridViewSinhVien.SelectedRows.Count > 0)
            {
                // Lấy sinh viên được chọn từ danh sách
                SinhVien sinhVienCanXoa = (SinhVien)dataGridViewSinhVien.SelectedRows[0].DataBoundItem;

                // Xóa sinh viên đó khỏi danh sách
                _danhSachSinhVien.Remove(sinhVienCanXoa);

                // Cập nhật lại DataSource của DataGridView
                dataGridViewSinhVien.DataSource = null;
                dataGridViewSinhVien.DataSource = _danhSachSinhVien;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sinh viên để xóa.");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có sinh viên nào được chọn để sửa không
            if (dataGridViewSinhVien.SelectedRows.Count > 0)
            {
                // Lấy sinh viên được chọn từ danh sách
                SinhVien sinhVienCanSua = (SinhVien)dataGridViewSinhVien.SelectedRows[0].DataBoundItem;

                // Cập nhật thông tin của sinh viên từ các control
                sinhVienCanSua.MaSV = txtMaSV.Text;
                sinhVienCanSua.TenSV = txtTenSV.Text;
                DateTime ngaySinh;
                if (DateTime.TryParse(dateTimePickerNgaySinh.Text, out ngaySinh))
                {
                    sinhVienCanSua.NgaySinh = ngaySinh;
                }
                sinhVienCanSua.Lop = txtLop.Text;
                float diem;
                if (float.TryParse(txtDiem.Text, out diem))
                {
                    sinhVienCanSua.Diem = diem;
                }

                // Cập nhật lại DataSource của DataGridView
                dataGridViewSinhVien.DataSource = null;
                dataGridViewSinhVien.DataSource = _danhSachSinhVien;

                // Xóa dữ liệu trên các control sau khi đã lưu thành công
                ClearInputControls();
            }
        }
        private void ClearInputControls()
        {
            txtMaSV.Text = "";
            txtTenSV.Text = "";
            dateTimePickerNgaySinh.Text = "";
            txtLop.Text = "";
            txtDiem.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
