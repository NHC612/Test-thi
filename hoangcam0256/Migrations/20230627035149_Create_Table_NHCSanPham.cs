using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hoangcam0256.Migrations
{
    /// <inheritdoc />
    public partial class Create_Table_NHCSanPham : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NHC256SanPham",
                columns: table => new
                {
                    NHC256MaSanPham = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NHC256TenSanPham = table.Column<string>(type: "TEXT", nullable: false),
                    NHC256Address = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NHC256SanPham", x => x.NHC256MaSanPham);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NHC256SanPham");
        }
    }
}
