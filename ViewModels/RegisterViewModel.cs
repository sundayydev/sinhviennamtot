using CSDLNC_QuanLySVNamTot.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CSDLNC_QuanLySVNamTot.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Tên đăng nhập không được để trống!")]
        [StringLength(50, ErrorMessage = "Tên đăng nhập không được quá 50 ký tự!")]
        public string TenDangNhap { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống!")]
        [DataType(DataType.Password)]
        public string MatKhau { get; set; }

        [Required(ErrorMessage = "Loại tài khoản không được để trống!")]
        public string LoaiTaiKhoan { get; set; } = "User"; // User, Reviewer
    }
}
