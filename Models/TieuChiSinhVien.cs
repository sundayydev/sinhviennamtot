using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSDLNC_QuanLySVNamTot.Models
{
    public class TieuChiSinhVien
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Mã đánh giá")]
        public int MaDanhGia { get; set; }

     
        [Required(ErrorMessage = "Điểm không được để trống")]
        public string DanhGia { get; set; }

        [DisplayName("Nhận xét")]
        public string? NhanXet { get; set; }

        [ForeignKey("SinhVien")]
        public string MaSinhVien { get; set; }
        public SinhVien? SinhVien { get; set; }

        [ForeignKey("TieuChi")]
        public int MaTieuChi { get; set; }
        public TieuChi? TieuChi { get; set; }


    }
}
