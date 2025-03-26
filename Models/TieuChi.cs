using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSDLNC_QuanLySVNamTot.Models
{
    public class TieuChi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaTieuChi { get; set; }

        [StringLength(100, ErrorMessage = "Tên tiêu chí không quá 100 ký tự!")]
        [Required(ErrorMessage = "Tên tiêu chí không được bỏ trống!")]
        public string TenTieuChi { get; set; }

        public string MoTa { get; set; }
    }
}
