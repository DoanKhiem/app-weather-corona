using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TungQLSV
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        void ThemSinhVien(SinhVien sv);

        [OperationContract]
        void SuaSinhVien(SinhVien sv);

        [OperationContract]
        void XoaSinhVien(string maSV);

        [OperationContract]
        List<SinhVien> LayDanhSachSinhVien();
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class SinhVien
    {
        [DataMember]
        public string MaSV { get; set; }

        [DataMember]
        public string TenSV { get; set; }

        [DataMember]
        public DateTime NgaySinh { get; set; }

        [DataMember]
        public string Lop { get; set; }

        [DataMember]
        public float Diem { get; set; }
        public string XepLoai { get; set; }
    }
}
