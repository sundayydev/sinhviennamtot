using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSDLNC_QuanLySVNamTot.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNguoiXetDuyet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DangKys_NguoiXetDuyets_MaNguoiXetDuyet",
                table: "DangKys");

            migrationBuilder.AlterColumn<string>(
                name: "MaNguoiXetDuyet",
                table: "DangKys",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_DangKys_NguoiXetDuyets_MaNguoiXetDuyet",
                table: "DangKys",
                column: "MaNguoiXetDuyet",
                principalTable: "NguoiXetDuyets",
                principalColumn: "MaNguoiXetDuyet");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DangKys_NguoiXetDuyets_MaNguoiXetDuyet",
                table: "DangKys");

            migrationBuilder.AlterColumn<string>(
                name: "MaNguoiXetDuyet",
                table: "DangKys",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DangKys_NguoiXetDuyets_MaNguoiXetDuyet",
                table: "DangKys",
                column: "MaNguoiXetDuyet",
                principalTable: "NguoiXetDuyets",
                principalColumn: "MaNguoiXetDuyet",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
