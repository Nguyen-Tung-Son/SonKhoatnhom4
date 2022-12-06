using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SonKhoatnhom4.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableImportStorage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Warehouse_CategoryProduct_ProductID",
                table: "Warehouse");

            migrationBuilder.DropColumn(
                name: "SupplierID",
                table: "Warehouse");

            migrationBuilder.RenameColumn(
                name: "SupplierName",
                table: "Warehouse",
                newName: "Trangthai");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Warehouse",
                newName: "Tenncc");

            migrationBuilder.RenameColumn(
                name: "ItemsName",
                table: "Warehouse",
                newName: "TenHangHoa");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "Warehouse",
                newName: "MaHangHoa");

            migrationBuilder.RenameColumn(
                name: "ProvideId",
                table: "ImportStorage",
                newName: "SoLuong");

            migrationBuilder.RenameColumn(
                name: "DateStorage",
                table: "ImportStorage",
                newName: "NgayNhapKho");

            migrationBuilder.RenameColumn(
                name: "AssetId",
                table: "ImportStorage",
                newName: "Mancc");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "ImportStorage",
                newName: "MaHangHoa");

            migrationBuilder.RenameColumn(
                name: "ImportStorageId",
                table: "ImportStorage",
                newName: "MaNhapKho");

            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "CategoryProduct",
                newName: "Thongtinhanghoa");

            migrationBuilder.RenameColumn(
                name: "ProductInformation",
                table: "CategoryProduct",
                newName: "TenHangHoa");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "CategoryProduct",
                newName: "MaHangHoa");

            migrationBuilder.AddColumn<string>(
                name: "Mancc",
                table: "Warehouse",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Warehouse_Mancc",
                table: "Warehouse",
                column: "Mancc");

            migrationBuilder.CreateIndex(
                name: "IX_ImportStorage_MaHangHoa",
                table: "ImportStorage",
                column: "MaHangHoa");

            migrationBuilder.CreateIndex(
                name: "IX_ImportStorage_Mancc",
                table: "ImportStorage",
                column: "Mancc");

            migrationBuilder.AddForeignKey(
                name: "FK_ImportStorage_CategoryProduct_MaHangHoa",
                table: "ImportStorage",
                column: "MaHangHoa",
                principalTable: "CategoryProduct",
                principalColumn: "MaHangHoa");

            migrationBuilder.AddForeignKey(
                name: "FK_ImportStorage_DanhsachNCC_Mancc",
                table: "ImportStorage",
                column: "Mancc",
                principalTable: "DanhsachNCC",
                principalColumn: "Mancc");

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouse_CategoryProduct_MaHangHoa",
                table: "Warehouse",
                column: "MaHangHoa",
                principalTable: "CategoryProduct",
                principalColumn: "MaHangHoa",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouse_DanhsachNCC_Mancc",
                table: "Warehouse",
                column: "Mancc",
                principalTable: "DanhsachNCC",
                principalColumn: "Mancc");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImportStorage_CategoryProduct_MaHangHoa",
                table: "ImportStorage");

            migrationBuilder.DropForeignKey(
                name: "FK_ImportStorage_DanhsachNCC_Mancc",
                table: "ImportStorage");

            migrationBuilder.DropForeignKey(
                name: "FK_Warehouse_CategoryProduct_MaHangHoa",
                table: "Warehouse");

            migrationBuilder.DropForeignKey(
                name: "FK_Warehouse_DanhsachNCC_Mancc",
                table: "Warehouse");

            migrationBuilder.DropIndex(
                name: "IX_Warehouse_Mancc",
                table: "Warehouse");

            migrationBuilder.DropIndex(
                name: "IX_ImportStorage_MaHangHoa",
                table: "ImportStorage");

            migrationBuilder.DropIndex(
                name: "IX_ImportStorage_Mancc",
                table: "ImportStorage");

            migrationBuilder.DropColumn(
                name: "Mancc",
                table: "Warehouse");

            migrationBuilder.RenameColumn(
                name: "Trangthai",
                table: "Warehouse",
                newName: "SupplierName");

            migrationBuilder.RenameColumn(
                name: "Tenncc",
                table: "Warehouse",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "TenHangHoa",
                table: "Warehouse",
                newName: "ItemsName");

            migrationBuilder.RenameColumn(
                name: "MaHangHoa",
                table: "Warehouse",
                newName: "ProductID");

            migrationBuilder.RenameColumn(
                name: "SoLuong",
                table: "ImportStorage",
                newName: "ProvideId");

            migrationBuilder.RenameColumn(
                name: "NgayNhapKho",
                table: "ImportStorage",
                newName: "DateStorage");

            migrationBuilder.RenameColumn(
                name: "Mancc",
                table: "ImportStorage",
                newName: "AssetId");

            migrationBuilder.RenameColumn(
                name: "MaHangHoa",
                table: "ImportStorage",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "MaNhapKho",
                table: "ImportStorage",
                newName: "ImportStorageId");

            migrationBuilder.RenameColumn(
                name: "Thongtinhanghoa",
                table: "CategoryProduct",
                newName: "ProductName");

            migrationBuilder.RenameColumn(
                name: "TenHangHoa",
                table: "CategoryProduct",
                newName: "ProductInformation");

            migrationBuilder.RenameColumn(
                name: "MaHangHoa",
                table: "CategoryProduct",
                newName: "ProductID");

            migrationBuilder.AddColumn<int>(
                name: "SupplierID",
                table: "Warehouse",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouse_CategoryProduct_ProductID",
                table: "Warehouse",
                column: "ProductID",
                principalTable: "CategoryProduct",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
