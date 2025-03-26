using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CSDLNC_QuanLySVNamTot.Models
{
    [Index(nameof(TenDangNhap), IsUnique = true)]
    public class TaiKhoan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaTaiKhoan { get; set; }

        [Required(ErrorMessage = "Tên đăng nhập không được để trống!")]
        [MaxLength(10, ErrorMessage = "Mã sinh viên không được nhập quá 10 ký tự!")]
        public string TenDangNhap { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống!")]
        [DataType(DataType.Password)]
        public string MatKhau { get; set; }

        [Required(ErrorMessage = "Loại tài khoản không được để trống!")]
        public string LoaiTaiKhoan { get; set; } = "User"; // User, Reviewer

        // Quan hệ 1-1 với SinhVien
        public string? MaSV { get; set; }

        [ForeignKey("MaSV")]
        public virtual SinhVien SinhVien { get; set; }


        // Quan hệ 1-1 với Người xét duyệt (nếu là reviewer)
        public string? MaNguoiXetDuyet { get; set; }

        [ForeignKey("MaNguoiXetDuyet")]
        public virtual NguoiXetDuyet NguoiXetDuyet { get; set; }
    }
}
