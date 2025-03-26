﻿// <auto-generated />
using System;
using CSDLNC_QuanLySVNamTot.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CSDLNC_QuanLySVNamTot.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20250326082229_UpdateThamGiaHD")]
    partial class UpdateThamGiaHD
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CSDLNC_QuanLySVNamTot.Models.DangKy", b =>
                {
                    b.Property<int>("MaDangKy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaDangKy"));

                    b.Property<string>("MaNguoiXetDuyet")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaSinhVien")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("NgayDangKy")
                        .HasColumnType("datetime2");

                    b.Property<string>("TrangThai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaDangKy");

                    b.HasIndex("MaNguoiXetDuyet");

                    b.HasIndex("MaSinhVien");

                    b.ToTable("DangKys");
                });

            modelBuilder.Entity("CSDLNC_QuanLySVNamTot.Models.KetQua", b =>
                {
                    b.Property<int>("MaKetQua")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaKetQua"));

                    b.Property<string>("MaNguoiXetDuyet")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaSinhVien")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("NamHoc")
                        .HasColumnType("int");

                    b.Property<string>("XetLoai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaKetQua");

                    b.HasIndex("MaNguoiXetDuyet");

                    b.HasIndex("MaSinhVien");

                    b.ToTable("KetQuas");
                });

            modelBuilder.Entity("CSDLNC_QuanLySVNamTot.Models.Khoa", b =>
                {
                    b.Property<int>("MaKhoa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaKhoa"));

                    b.Property<string>("TenKhoa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaKhoa");

                    b.ToTable("Khoas");
                });

            modelBuilder.Entity("CSDLNC_QuanLySVNamTot.Models.Lop", b =>
                {
                    b.Property<int>("MaLop")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaLop"));

                    b.Property<int>("MaKhoa")
                        .HasColumnType("int");

                    b.Property<string>("TenLop")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MaLop");

                    b.HasIndex("MaKhoa");

                    b.ToTable("Lops");
                });

            modelBuilder.Entity("CSDLNC_QuanLySVNamTot.Models.NguoiXetDuyet", b =>
                {
                    b.Property<string>("MaNguoiXetDuyet")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SoDienThoai")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("MaNguoiXetDuyet");

                    b.ToTable("NguoiXetDuyets");
                });

            modelBuilder.Entity("CSDLNC_QuanLySVNamTot.Models.SinhVien", b =>
                {
                    b.Property<string>("MaSV")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("GioiTinh")
                        .HasColumnType("bit");

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("MaLop")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<string>("SoDienThoai")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("MaSV");

                    b.HasIndex("MaLop");

                    b.ToTable("SinhViens");
                });

            modelBuilder.Entity("CSDLNC_QuanLySVNamTot.Models.TaiKhoan", b =>
                {
                    b.Property<int>("MaTaiKhoan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaTaiKhoan"));

                    b.Property<string>("LoaiTaiKhoan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaNguoiXetDuyet")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaSV")
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("MatKhau")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenDangNhap")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("MaTaiKhoan");

                    b.HasIndex("MaNguoiXetDuyet")
                        .IsUnique()
                        .HasFilter("[MaNguoiXetDuyet] IS NOT NULL");

                    b.HasIndex("MaSV")
                        .IsUnique()
                        .HasFilter("[MaSV] IS NOT NULL");

                    b.HasIndex("TenDangNhap")
                        .IsUnique();

                    b.ToTable("TaiKhoans");
                });

            modelBuilder.Entity("CSDLNC_QuanLySVNamTot.Models.ThamGiaHoatDong", b =>
                {
                    b.Property<int>("MaHoatDong")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaHoatDong"));

                    b.Property<string>("MaSinhVien")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("MaTieuChi")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayThamGia")
                        .HasColumnType("datetime2");

                    b.Property<string>("TenHoatDong")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaHoatDong");

                    b.HasIndex("MaSinhVien");

                    b.HasIndex("MaTieuChi");

                    b.ToTable("ThamGiaHoatDongs");
                });

            modelBuilder.Entity("CSDLNC_QuanLySVNamTot.Models.TieuChi", b =>
                {
                    b.Property<int>("MaTieuChi")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaTieuChi"));

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenTieuChi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MaTieuChi");

                    b.ToTable("TieuChis");
                });

            modelBuilder.Entity("CSDLNC_QuanLySVNamTot.Models.TieuChiSinhVien", b =>
                {
                    b.Property<int>("MaDanhGia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaDanhGia"));

                    b.Property<string>("DanhGia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaSinhVien")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("MaTieuChi")
                        .HasColumnType("int");

                    b.Property<string>("NhanXet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaDanhGia");

                    b.HasIndex("MaSinhVien");

                    b.HasIndex("MaTieuChi");

                    b.ToTable("TieuChiSinhViens");
                });

            modelBuilder.Entity("CSDLNC_QuanLySVNamTot.Models.DangKy", b =>
                {
                    b.HasOne("CSDLNC_QuanLySVNamTot.Models.NguoiXetDuyet", "NguoiXetDuyet")
                        .WithMany()
                        .HasForeignKey("MaNguoiXetDuyet");

                    b.HasOne("CSDLNC_QuanLySVNamTot.Models.SinhVien", "SinhVien")
                        .WithMany()
                        .HasForeignKey("MaSinhVien")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NguoiXetDuyet");

                    b.Navigation("SinhVien");
                });

            modelBuilder.Entity("CSDLNC_QuanLySVNamTot.Models.KetQua", b =>
                {
                    b.HasOne("CSDLNC_QuanLySVNamTot.Models.NguoiXetDuyet", "NguoiXetDuyet")
                        .WithMany()
                        .HasForeignKey("MaNguoiXetDuyet")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CSDLNC_QuanLySVNamTot.Models.SinhVien", "SinhVien")
                        .WithMany()
                        .HasForeignKey("MaSinhVien")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NguoiXetDuyet");

                    b.Navigation("SinhVien");
                });

            modelBuilder.Entity("CSDLNC_QuanLySVNamTot.Models.Lop", b =>
                {
                    b.HasOne("CSDLNC_QuanLySVNamTot.Models.Khoa", "Khoa")
                        .WithMany()
                        .HasForeignKey("MaKhoa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Khoa");
                });

            modelBuilder.Entity("CSDLNC_QuanLySVNamTot.Models.SinhVien", b =>
                {
                    b.HasOne("CSDLNC_QuanLySVNamTot.Models.Lop", "Lop")
                        .WithMany()
                        .HasForeignKey("MaLop")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lop");
                });

            modelBuilder.Entity("CSDLNC_QuanLySVNamTot.Models.TaiKhoan", b =>
                {
                    b.HasOne("CSDLNC_QuanLySVNamTot.Models.NguoiXetDuyet", "NguoiXetDuyet")
                        .WithOne("TaiKhoan")
                        .HasForeignKey("CSDLNC_QuanLySVNamTot.Models.TaiKhoan", "MaNguoiXetDuyet");

                    b.HasOne("CSDLNC_QuanLySVNamTot.Models.SinhVien", "SinhVien")
                        .WithOne("TaiKhoan")
                        .HasForeignKey("CSDLNC_QuanLySVNamTot.Models.TaiKhoan", "MaSV");

                    b.Navigation("NguoiXetDuyet");

                    b.Navigation("SinhVien");
                });

            modelBuilder.Entity("CSDLNC_QuanLySVNamTot.Models.ThamGiaHoatDong", b =>
                {
                    b.HasOne("CSDLNC_QuanLySVNamTot.Models.SinhVien", "SinhVien")
                        .WithMany()
                        .HasForeignKey("MaSinhVien")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CSDLNC_QuanLySVNamTot.Models.TieuChi", "TieuChi")
                        .WithMany()
                        .HasForeignKey("MaTieuChi")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SinhVien");

                    b.Navigation("TieuChi");
                });

            modelBuilder.Entity("CSDLNC_QuanLySVNamTot.Models.TieuChiSinhVien", b =>
                {
                    b.HasOne("CSDLNC_QuanLySVNamTot.Models.SinhVien", "SinhVien")
                        .WithMany()
                        .HasForeignKey("MaSinhVien")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CSDLNC_QuanLySVNamTot.Models.TieuChi", "TieuChi")
                        .WithMany()
                        .HasForeignKey("MaTieuChi")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SinhVien");

                    b.Navigation("TieuChi");
                });

            modelBuilder.Entity("CSDLNC_QuanLySVNamTot.Models.NguoiXetDuyet", b =>
                {
                    b.Navigation("TaiKhoan")
                        .IsRequired();
                });

            modelBuilder.Entity("CSDLNC_QuanLySVNamTot.Models.SinhVien", b =>
                {
                    b.Navigation("TaiKhoan")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
