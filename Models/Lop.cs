using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSDLNC_QuanLySVNamTot.Models
{
    public class Lop
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaLop { get; set; }

        [Required(ErrorMessage = "Bạn không được để trống tên lớp!")]
        [StringLength(100, ErrorMessage = "Bạn không được nhập quá 100 ký tự!")]
        public string TenLop { get; set; }

        [Required(ErrorMessage = "Bạn không được để trống mã khoa!")]
        [ForeignKey("Khoa")]
        public int MaKhoa { get; set; }
        public Khoa Khoa { get; set; }
    }
}
