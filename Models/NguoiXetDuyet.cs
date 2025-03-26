using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSDLNC_QuanLySVNamTot.Models
{
    public class NguoiXetDuyet
    {
        [Key]
        public string MaNguoiXetDuyet { get; set; }

        [Required(ErrorMessage = "Họ tên không được để trống!")]
        [StringLength(50, ErrorMessage = "Họ tên không được quá 50 ký tự!")]
        public string HoTen { get; set; }

        [Required(ErrorMessage = "Email không được để trống!")] 
        public string Email { get; set; }

        [Required(ErrorMessage = "Số điện thoại không được để trống!")]
        [StringLength(11, ErrorMessage = "Số điện thoại không được quá 11 ký tự!")]
        public string SoDienThoai { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
