using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSDLNC_QuanLySVNamTot.Models
{
    public class ThamGiaHoatDong
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaHoatDong { get; set; }

        [Required(ErrorMessage = "Tên hoạt động không được để trống")]
        public string TenHoatDong { get; set; }

        [Required(ErrorMessage = "Ngày tham gia không được để trống")]
        public DateTime NgayThamGia { get; set; }

        [ForeignKey("SinhVien")]
        public string MaSinhVien { get; set; }

        [Required(ErrorMessage = "Sinh viên không được để trống")]
        public SinhVien SinhVien { get; set; }

        [ForeignKey("TieuChi")]
        public int MaTieuChi { get; set; } // Khóa ngoại liên kết với TieuChi

        [Required(ErrorMessage = "Tiêu chí không được để trống")]
        public TieuChi TieuChi { get; set; } // Quan hệ navigation
    }
}