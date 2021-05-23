using Microsoft.EntityFrameworkCore.Migrations;

namespace Games.Microservice.Migrations
{
    public partial class changedtablenames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Teams_GameId",
                table: "Players");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teams",
                table: "Teams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Players",
                table: "Players");

            migrationBuilder.RenameTable(
                name: "Teams",
                newName: "Games");

            migrationBuilder.RenameTable(
                name: "Players",
                newName: "GameEvents");

            migrationBuilder.RenameIndex(
                name: "IX_Players_GameId",
                table: "GameEvents",
                newName: "IX_GameEvents_GameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Games",
                table: "Games",
                column: "GameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameEvents",
                table: "GameEvents",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameEvents_Games_GameId",
                table: "GameEvents",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameEvents_Games_GameId",
                table: "GameEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Games",
                table: "Games");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameEvents",
                table: "GameEvents");

            migrationBuilder.RenameTable(
                name: "Games",
                newName: "Teams");

            migrationBuilder.RenameTable(
                name: "GameEvents",
                newName: "Players");

            migrationBuilder.RenameIndex(
                name: "IX_GameEvents_GameId",
                table: "Players",
                newName: "IX_Players_GameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teams",
                table: "Teams",
                column: "GameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Players",
                table: "Players",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Teams_GameId",
                table: "Players",
                column: "GameId",
                principalTable: "Teams",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
