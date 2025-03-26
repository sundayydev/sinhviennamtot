using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSDLNC_QuanLySVNamTot.Models
{
    public class DangKy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Mã đăng ký")]
        public int MaDangKy { get; set; }

        [DisplayName("Ngày đăng ký")]
        public DateTime NgayDangKy { get; set; }

        [DisplayName("Trạng thái")]
        public string TrangThai { get; set; } = "Chờ xét duyệt";

        [ForeignKey("SinhVien")]
        public string MaSinhVien { get; set; }
        public virtual SinhVien SinhVien { get; set; }

        [ForeignKey("NguoiXetDuyet")]
        public string? MaNguoiXetDuyet { get; set; }
        public  NguoiXetDuyet? NguoiXetDuyet { get; set; }
    }
}
