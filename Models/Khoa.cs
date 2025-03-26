using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSDLNC_QuanLySVNamTot.Models
{
    public class Khoa
    {
        [Key]
        [DisplayName("Mã Khoa")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaKhoa { get; set; }

        [Required(ErrorMessage = "Tên Khoa không được để trống")]
        [DisplayName("Tên Khoa")]
        public string TenKhoa { get; set; }


    }
}
