using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSDLNC_QuanLySVNamTot.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTypeSinhVien : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Khoas",
                columns: table => new
                {
                    MaKhoa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKhoa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khoas", x => x.MaKhoa);
                });

            migrationBuilder.CreateTable(
                name: "NguoiXetDuyets",
                columns: table => new
                {
                    MaNguoiXetDuyet = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiXetDuyets", x => x.MaNguoiXetDuyet);
                });

            migrationBuilder.CreateTable(
                name: "TieuChis",
                columns: table => new
                {
                    MaTieuChi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTieuChi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TieuChis", x => x.MaTieuChi);
                });

            migrationBuilder.CreateTable(
                name: "Lops",
                columns: table => new
                {
                    MaLop = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLop = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaKhoa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lops", x => x.MaLop);
                    table.ForeignKey(
                        name: "FK_Lops_Khoas_MaKhoa",
                        column: x => x.MaKhoa,
                        principalTable: "Khoas",
                        principalColumn: "MaKhoa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SinhViens",
                columns: table => new
                {
                    MaSV = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GioiTinh = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    MaLop = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinhViens", x => x.MaSV);
                    table.ForeignKey(
                        name: "FK_SinhViens_Lops_MaLop",
                        column: x => x.MaLop,
                        principalTable: "Lops",
                        principalColumn: "MaLop",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DangKys",
                columns: table => new
                {
                    MaDangKy = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayDangKy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaSinhVien = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    MaNguoiXetDuyet = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DangKys", x => x.MaDangKy);
                    table.ForeignKey(
                        name: "FK_DangKys_NguoiXetDuyets_MaNguoiXetDuyet",
                        column: x => x.MaNguoiXetDuyet,
                        principalTable: "NguoiXetDuyets",
                        principalColumn: "MaNguoiXetDuyet",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DangKys_SinhViens_MaSinhVien",
                        column: x => x.MaSinhVien,
                        principalTable: "SinhViens",
                        principalColumn: "MaSV",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KetQuas",
                columns: table => new
                {
                    MaKetQua = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamHoc = table.Column<int>(type: "int", nullable: false),
                    XetLoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaSinhVien = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    MaNguoiXetDuyet = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KetQuas", x => x.MaKetQua);
                    table.ForeignKey(
                        name: "FK_KetQuas_NguoiXetDuyets_MaNguoiXetDuyet",
                        column: x => x.MaNguoiXetDuyet,
                        principalTable: "NguoiXetDuyets",
                        principalColumn: "MaNguoiXetDuyet",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KetQuas_SinhViens_MaSinhVien",
                        column: x => x.MaSinhVien,
                        principalTable: "SinhViens",
                        principalColumn: "MaSV",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoans",
                columns: table => new
                {
                    MaTaiKhoan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDangNhap = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoaiTaiKhoan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaSV = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    MaNguoiXetDuyet = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoans", x => x.MaTaiKhoan);
                    table.ForeignKey(
                        name: "FK_TaiKhoans_NguoiXetDuyets_MaNguoiXetDuyet",
                        column: x => x.MaNguoiXetDuyet,
                        principalTable: "NguoiXetDuyets",
                        principalColumn: "MaNguoiXetDuyet");
                    table.ForeignKey(
                        name: "FK_TaiKhoans_SinhViens_MaSV",
                        column: x => x.MaSV,
                        principalTable: "SinhViens",
                        principalColumn: "MaSV");
                });

            migrationBuilder.CreateTable(
                name: "ThamGiaHoatDongs",
                columns: table => new
                {
                    MaHoatDong = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenHoatDong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayThamGia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Diem = table.Column<int>(type: "int", nullable: false),
                    MaSinhVien = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThamGiaHoatDongs", x => x.MaHoatDong);
                    table.ForeignKey(
                        name: "FK_ThamGiaHoatDongs_SinhViens_MaSinhVien",
                        column: x => x.MaSinhVien,
                        principalTable: "SinhViens",
                        principalColumn: "MaSV",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TieuChiSinhViens",
                columns: table => new
                {
                    MaDanhGia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Diem = table.Column<int>(type: "int", nullable: false),
                    NhanXet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaSinhVien = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    MaTieuChi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TieuChiSinhViens", x => x.MaDanhGia);
                    table.ForeignKey(
                        name: "FK_TieuChiSinhViens_SinhViens_MaSinhVien",
                        column: x => x.MaSinhVien,
                        principalTable: "SinhViens",
                        principalColumn: "MaSV",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TieuChiSinhViens_TieuChis_MaTieuChi",
                        column: x => x.MaTieuChi,
                        principalTable: "TieuChis",
                        principalColumn: "MaTieuChi",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DangKys_MaNguoiXetDuyet",
                table: "DangKys",
                column: "MaNguoiXetDuyet");

            migrationBuilder.CreateIndex(
                name: "IX_DangKys_MaSinhVien",
                table: "DangKys",
                column: "MaSinhVien");

            migrationBuilder.CreateIndex(
                name: "IX_KetQuas_MaNguoiXetDuyet",
                table: "KetQuas",
                column: "MaNguoiXetDuyet");

            migrationBuilder.CreateIndex(
                name: "IX_KetQuas_MaSinhVien",
                table: "KetQuas",
                column: "MaSinhVien");

            migrationBuilder.CreateIndex(
                name: "IX_Lops_MaKhoa",
                table: "Lops",
                column: "MaKhoa");

            migrationBuilder.CreateIndex(
                name: "IX_SinhViens_MaLop",
                table: "SinhViens",
                column: "MaLop");

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoans_MaNguoiXetDuyet",
                table: "TaiKhoans",
                column: "MaNguoiXetDuyet",
                unique: true,
                filter: "[MaNguoiXetDuyet] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoans_MaSV",
                table: "TaiKhoans",
                column: "MaSV",
                unique: true,
                filter: "[MaSV] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoans_TenDangNhap",
                table: "TaiKhoans",
                column: "TenDangNhap",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ThamGiaHoatDongs_MaSinhVien",
                table: "ThamGiaHoatDongs",
                column: "MaSinhVien");

            migrationBuilder.CreateIndex(
                name: "IX_TieuChiSinhViens_MaSinhVien",
                table: "TieuChiSinhViens",
                column: "MaSinhVien");

            migrationBuilder.CreateIndex(
                name: "IX_TieuChiSinhViens_MaTieuChi",
                table: "TieuChiSinhViens",
                column: "MaTieuChi");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DangKys");

            migrationBuilder.DropTable(
                name: "KetQuas");

            migrationBuilder.DropTable(
                name: "TaiKhoans");

            migrationBuilder.DropTable(
                name: "ThamGiaHoatDongs");

            migrationBuilder.DropTable(
                name: "TieuChiSinhViens");

            migrationBuilder.DropTable(
                name: "NguoiXetDuyets");

            migrationBuilder.DropTable(
                name: "SinhViens");

            migrationBuilder.DropTable(
                name: "TieuChis");

            migrationBuilder.DropTable(
                name: "Lops");

            migrationBuilder.DropTable(
                name: "Khoas");
        }
    }
}
