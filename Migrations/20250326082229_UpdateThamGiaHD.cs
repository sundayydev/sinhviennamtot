using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSDLNC_QuanLySVNamTot.Migrations
{
    /// <inheritdoc />
    public partial class UpdateThamGiaHD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Diem",
                table: "TieuChiSinhViens");

            migrationBuilder.RenameColumn(
                name: "Diem",
                table: "ThamGiaHoatDongs",
                newName: "MaTieuChi");

            migrationBuilder.AddColumn<string>(
                name: "DanhGia",
                table: "TieuChiSinhViens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ThamGiaHoatDongs_MaTieuChi",
                table: "ThamGiaHoatDongs",
                column: "MaTieuChi");

            migrationBuilder.AddForeignKey(
                name: "FK_ThamGiaHoatDongs_TieuChis_MaTieuChi",
                table: "ThamGiaHoatDongs",
                column: "MaTieuChi",
                principalTable: "TieuChis",
                principalColumn: "MaTieuChi",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThamGiaHoatDongs_TieuChis_MaTieuChi",
                table: "ThamGiaHoatDongs");

            migrationBuilder.DropIndex(
                name: "IX_ThamGiaHoatDongs_MaTieuChi",
                table: "ThamGiaHoatDongs");

            migrationBuilder.DropColumn(
                name: "DanhGia",
                table: "TieuChiSinhViens");

            migrationBuilder.RenameColumn(
                name: "MaTieuChi",
                table: "ThamGiaHoatDongs",
                newName: "Diem");

            migrationBuilder.AddColumn<int>(
                name: "Diem",
                table: "TieuChiSinhViens",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
