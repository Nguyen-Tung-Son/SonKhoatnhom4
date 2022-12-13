using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SonKhoatnhom4.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableWarehouse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Makhachhang",
                table: "Warehouse",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Warehouse_Makhachhang",
                table: "Warehouse",
                column: "Makhachhang");

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouse_Danhsachkhachhang_Makhachhang",
                table: "Warehouse",
                column: "Makhachhang",
                principalTable: "Danhsachkhachhang",
                principalColumn: "Makhachhang");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Warehouse_Danhsachkhachhang_Makhachhang",
                table: "Warehouse");

            migrationBuilder.DropIndex(
                name: "IX_Warehouse_Makhachhang",
                table: "Warehouse");

            migrationBuilder.DropColumn(
                name: "Makhachhang",
                table: "Warehouse");
        }
    }
}
