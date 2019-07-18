using Microsoft.EntityFrameworkCore.Migrations;

namespace HM.Data.Migrations
{
    public partial class WordsOverhaul : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Words_Categories_CategoryID",
                table: "Words");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                table: "Words",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Words_Categories_CategoryID",
                table: "Words",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Words_Categories_CategoryID",
                table: "Words");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                table: "Words",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Words_Categories_CategoryID",
                table: "Words",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
