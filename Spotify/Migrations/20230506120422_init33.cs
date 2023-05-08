using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Spotify.Migrations
{
    /// <inheritdoc />
    public partial class init33 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_AlbumCategory_AlbumCategoryId",
                table: "Albums");

            migrationBuilder.DropTable(
                name: "AlbumCategory");

            migrationBuilder.RenameColumn(
                name: "AlbumCategoryId",
                table: "Albums",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Albums_AlbumCategoryId",
                table: "Albums",
                newName: "IX_Albums_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Categories_CategoryId",
                table: "Albums",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Categories_CategoryId",
                table: "Albums");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Albums",
                newName: "AlbumCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Albums_CategoryId",
                table: "Albums",
                newName: "IX_Albums_AlbumCategoryId");

            migrationBuilder.CreateTable(
                name: "AlbumCategory",
                columns: table => new
                {
                    AlbumId = table.Column<int>(type: "int", nullable: false),
                    AlbumCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumCategory", x => x.AlbumId);
                    table.ForeignKey(
                        name: "FK_AlbumCategory_Albums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlbumCategory_Categories_AlbumCategoryId",
                        column: x => x.AlbumCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlbumCategory_AlbumCategoryId",
                table: "AlbumCategory",
                column: "AlbumCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_AlbumCategory_AlbumCategoryId",
                table: "Albums",
                column: "AlbumCategoryId",
                principalTable: "AlbumCategory",
                principalColumn: "AlbumId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
