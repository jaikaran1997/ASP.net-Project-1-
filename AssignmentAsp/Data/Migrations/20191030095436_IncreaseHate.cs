using Microsoft.EntityFrameworkCore.Migrations;

namespace AssignmentAsp.Data.Migrations
{
    public partial class IncreaseHate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "canIncreaseHate",
                table: "MachineLearningCompaniesFeedback",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "canIncreaseHate",
                table: "MachineLearningCompaniesFeedback");
        }
    }
}
