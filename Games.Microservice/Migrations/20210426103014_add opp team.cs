using Microsoft.EntityFrameworkCore.Migrations;

namespace Games.Microservice.Migrations
{
    public partial class addoppteam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OppTeamId",
                table: "GameEvents",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OppTeamId",
                table: "GameEvents");
        }
    }
}
