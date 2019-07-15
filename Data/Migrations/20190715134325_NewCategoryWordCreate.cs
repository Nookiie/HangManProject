using Microsoft.EntityFrameworkCore.Migrations;

namespace HM.Data.Migrations
{
    public partial class NewCategoryWordCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Words",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Words_CategoryID",
                table: "Words",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Words_Categories_CategoryID",
                table: "Words",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Words_Categories_CategoryID",
                table: "Words");

            migrationBuilder.DropIndex(
                name: "IX_Words_CategoryID",
                table: "Words");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Words");
        }
    }
}
