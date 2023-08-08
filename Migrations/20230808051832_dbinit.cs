using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CuaHangHoaQua.Migrations
{
    /// <inheritdoc />
    public partial class dbinit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoaiThucPhams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoai = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiThucPhams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThucPhams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThucPhams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ViTris",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ke = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViTris", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoaiThucPham_ThucPhams",
                columns: table => new
                {
                    ThucPhamId = table.Column<int>(type: "int", nullable: false),
                    LoaiThucPhamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiThucPham_ThucPhams", x => new { x.LoaiThucPhamId, x.ThucPhamId });
                    table.ForeignKey(
                        name: "FK_LoaiThucPham_ThucPhams_LoaiThucPhams_LoaiThucPhamId",
                        column: x => x.LoaiThucPhamId,
                        principalTable: "LoaiThucPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoaiThucPham_ThucPhams_ThucPhams_ThucPhamId",
                        column: x => x.ThucPhamId,
                        principalTable: "ThucPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ViTri_ThucPhams",
                columns: table => new
                {
                    ViTriId = table.Column<int>(type: "int", nullable: false),
                    ThucPhamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViTri_ThucPhams", x => new { x.ViTriId, x.ThucPhamId });
                    table.ForeignKey(
                        name: "FK_ViTri_ThucPhams_ThucPhams_ThucPhamId",
                        column: x => x.ThucPhamId,
                        principalTable: "ThucPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ViTri_ThucPhams_ViTris_ViTriId",
                        column: x => x.ViTriId,
                        principalTable: "ViTris",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoaiThucPham_ThucPhams_ThucPhamId",
                table: "LoaiThucPham_ThucPhams",
                column: "ThucPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_ViTri_ThucPhams_ThucPhamId",
                table: "ViTri_ThucPhams",
                column: "ThucPhamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoaiThucPham_ThucPhams");

            migrationBuilder.DropTable(
                name: "ViTri_ThucPhams");

            migrationBuilder.DropTable(
                name: "LoaiThucPhams");

            migrationBuilder.DropTable(
                name: "ThucPhams");

            migrationBuilder.DropTable(
                name: "ViTris");
        }
    }
}
