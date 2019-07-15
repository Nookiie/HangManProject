using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HM.Data.Migrations
{
    public partial class CategoriesCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Words_GameTrackers_GameTrackerID",
                table: "Words");

            migrationBuilder.DropTable(
                name: "GameTrackers");

            migrationBuilder.DropIndex(
                name: "IX_Words_GameTrackerID",
                table: "Words");

            migrationBuilder.DropColumn(
                name: "GameTrackerID",
                table: "Words");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "GameTrackerID",
                table: "Words",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GameTrackers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Category = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameTrackers", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Words_GameTrackerID",
                table: "Words",
                column: "GameTrackerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Words_GameTrackers_GameTrackerID",
                table: "Words",
                column: "GameTrackerID",
                principalTable: "GameTrackers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
