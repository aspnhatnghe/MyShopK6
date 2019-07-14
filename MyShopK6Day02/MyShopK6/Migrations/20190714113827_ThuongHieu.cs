using Microsoft.EntityFrameworkCore.Migrations;

namespace MyShopK6.Migrations
{
    public partial class ThuongHieu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TenHh",
                table: "HangHoa",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaTh",
                table: "HangHoa",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ThuongHieu",
                columns: table => new
                {
                    MaTh = table.Column<string>(maxLength: 50, nullable: false),
                    TenThuongHieu = table.Column<string>(maxLength: 50, nullable: false),
                    DiaChi = table.Column<string>(maxLength: 150, nullable: true),
                    DienThoai = table.Column<string>(maxLength: 50, nullable: true),
                    Logo = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThuongHieu", x => x.MaTh);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HangHoa_MaTh",
                table: "HangHoa",
                column: "MaTh");

            migrationBuilder.AddForeignKey(
                name: "FK_HangHoa_ThuongHieu_MaTh",
                table: "HangHoa",
                column: "MaTh",
                principalTable: "ThuongHieu",
                principalColumn: "MaTh",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HangHoa_ThuongHieu_MaTh",
                table: "HangHoa");

            migrationBuilder.DropTable(
                name: "ThuongHieu");

            migrationBuilder.DropIndex(
                name: "IX_HangHoa_MaTh",
                table: "HangHoa");

            migrationBuilder.DropColumn(
                name: "MaTh",
                table: "HangHoa");

            migrationBuilder.AlterColumn<string>(
                name: "TenHh",
                table: "HangHoa",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 150);
        }
    }
}
