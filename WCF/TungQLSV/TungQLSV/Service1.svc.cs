using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TungQLSV
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private List<SinhVien> _danhSachSinhVien = new List<SinhVien>();

        public void ThemSinhVien(SinhVien sv)
        {
            _danhSachSinhVien.Add(sv);
        }

        public void SuaSinhVien(SinhVien sv)
        {
            var sinhVienCanSua = _danhSachSinhVien.FirstOrDefault(x => x.MaSV == sv.MaSV);
            if (sinhVienCanSua != null)
            {
                // Cập nhật thông tin của sinh viên
                sinhVienCanSua.TenSV = sv.TenSV;
                sinhVienCanSua.NgaySinh = sv.NgaySinh;
                sinhVienCanSua.Lop = sv.Lop;
                sinhVienCanSua.Diem = sv.Diem;
                sinhVienCanSua.XepLoai = sv.XepLoai; // Nếu có cần cập nhật thông tin xếp loại
            }
        }

        public void XoaSinhVien(string maSV)
        {
            var sinhVienCanXoa = _danhSachSinhVien.FirstOrDefault(x => x.MaSV == maSV);
            if (sinhVienCanXoa != null)
            {
                _danhSachSinhVien.Remove(sinhVienCanXoa);
            }
        }

        public List<SinhVien> LayDanhSachSinhVien()
        {
            return _danhSachSinhVien;
        }
    }
}
