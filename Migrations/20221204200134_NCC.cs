using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SonKhoatnhom4.Migrations
{
    /// <inheritdoc />
    public partial class NCC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DanhsachNCC",
                columns: table => new
                {
                    Mancc = table.Column<string>(type: "TEXT", nullable: false),
                    Tenncc = table.Column<string>(type: "TEXT", nullable: false),
                    Sodienthoai = table.Column<int>(type: "INTEGER", nullable: false),
                    Diachi = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhsachNCC", x => x.Mancc);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DanhsachNCC");
        }
    }
}
