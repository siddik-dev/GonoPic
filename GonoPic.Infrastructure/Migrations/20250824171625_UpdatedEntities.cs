using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GonoPic.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Media_Categories_CategoryId",
                table: "Media");

            migrationBuilder.DropIndex(
                name: "IX_Media_CategoryId",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Media");

            migrationBuilder.CreateTable(
                name: "CategoryMedia",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    MediaItemsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryMedia", x => new { x.CategoriesId, x.MediaItemsId });
                    table.ForeignKey(
                        name: "FK_CategoryMedia_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryMedia_Media_MediaItemsId",
                        column: x => x.MediaItemsId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryMedia_MediaItemsId",
                table: "CategoryMedia",
                column: "MediaItemsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryMedia");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Media",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Media_CategoryId",
                table: "Media",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Media_Categories_CategoryId",
                table: "Media",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
