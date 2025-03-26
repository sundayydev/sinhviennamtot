using Microsoft.EntityFrameworkCore;

namespace CSDLNC_QuanLySVNamTot.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        { }

        public DbSet<Khoa> Khoas { get; set; }
        public DbSet<Lop> Lops { get; set; }
        public DbSet<SinhVien> SinhViens { get; set; }
        public DbSet<TaiKhoan> TaiKhoans { get; set; }
        public DbSet<NguoiXetDuyet> NguoiXetDuyets { get; set; }
        public DbSet<TieuChi> TieuChis { get; set; }
        public DbSet<DangKy> DangKys { get; set; }
        public DbSet<ThamGiaHoatDong> ThamGiaHoatDongs { get; set; }
        public DbSet<KetQua> KetQuas { get; set; }
        public DbSet<TieuChiSinhVien> TieuChiSinhViens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
