using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSDLNC_QuanLySVNamTot.Models
{
    public class KetQua
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Mã Kết Quả")]
        public int MaKetQua { get; set; }

        [Required(ErrorMessage = "Bạn không được để trống năm học!")]
        [DisplayName("Năm học")]
        public int NamHoc { get; set; }

        [Required(ErrorMessage = "Bạn không được để trống xếp loại!")]
        [DisplayName("Xếp loại")]
        public string XetLoai { get; set; }

        [ForeignKey("SinhVien")]
        public string MaSinhVien { get; set; }
        public SinhVien? SinhVien { get; set; }

        [ForeignKey("NguoiXetDuyet")]
        public string MaNguoiXetDuyet { get; set; }
        public NguoiXetDuyet? NguoiXetDuyet { get; set; }

    }
}
