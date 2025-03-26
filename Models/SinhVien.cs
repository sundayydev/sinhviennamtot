using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CSDLNC_QuanLySVNamTot.Models
{
    public class SinhVien
    {
        [Key]
        [DisplayName("Mã Sinh Viên")]
        [MaxLength(10, ErrorMessage = "Mã sinh viên không được nhập quá 10 ký tự!")]
        public string MaSV { get; set; }

        [Required(ErrorMessage = "Bạn không được để trống họ tên!")]
        [StringLength(50, ErrorMessage = "Bạn không được nhập quá 50 ký tự!")]
        [DisplayName("Họ Tên")]
        public string HoTen { get; set; }

        [Required(ErrorMessage = "Bạn không được để trống ngày sinh!")]
        [DisplayName("Ngày Sinh")]
        public DateTime NgaySinh { get; set; }

        [Required(ErrorMessage = "Bạn không được để trống giới tính!")]
        public bool GioiTinh { get; set; }


        [Required(ErrorMessage = "Bạn không được để trống địa chỉ!")]
        [StringLength(100), EmailAddress]
        public string Email { get; set; }


        [StringLength(11, ErrorMessage = "Bạn không được nhập số điện thoại quá 11 ký tự!")]
        public string SoDienThoai { get; set; }


        // Foreign Key
        [Required(ErrorMessage = "Bạn không được để trống mã lớp!")]
        [ForeignKey("Lop")]
        public int MaLop { get; set; }
        public Lop Lop { get; set; }

        // Quan hệ 1-1 với Account
        public TaiKhoan TaiKhoan { get; set; }
    }
}
