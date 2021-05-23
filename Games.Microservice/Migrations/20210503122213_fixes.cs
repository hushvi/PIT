using Microsoft.EntityFrameworkCore.Migrations;

namespace Games.Microservice.Migrations
{
    public partial class fixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalPlayerId",
                table: "GameEvents");

            migrationBuilder.DropColumn(
                name: "EventTeamId",
                table: "GameEvents");

            migrationBuilder.DropColumn(
                name: "OppTeamId",
                table: "GameEvents");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "GameEvents");

            migrationBuilder.AddColumn<int>(
                name: "Finished",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FirstTeamGoals",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Overtime",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SecondTeamGoals",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AdditionalPlayerName",
                table: "GameEvents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EventTeamName",
                table: "GameEvents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlayerName",
                table: "GameEvents",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Finished",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "FirstTeamGoals",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Overtime",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "SecondTeamGoals",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "AdditionalPlayerName",
                table: "GameEvents");

            migrationBuilder.DropColumn(
                name: "EventTeamName",
                table: "GameEvents");

            migrationBuilder.DropColumn(
                name: "PlayerName",
                table: "GameEvents");

            migrationBuilder.AddColumn<int>(
                name: "AdditionalPlayerId",
                table: "GameEvents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EventTeamId",
                table: "GameEvents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OppTeamId",
                table: "GameEvents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "GameEvents",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
