using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SonKhoatnhom4.Migrations
{
    /// <inheritdoc />
    public partial class Nhanvien : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Danhsachnhanvien",
                columns: table => new
                {
                    Manhanvien = table.Column<string>(type: "TEXT", nullable: false),
                    Tennhanvien = table.Column<string>(type: "TEXT", nullable: false),
                    Diachi = table.Column<string>(type: "TEXT", nullable: true),
                    Sodienthoai = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Danhsachnhanvien", x => x.Manhanvien);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Danhsachnhanvien");
        }
    }
}
