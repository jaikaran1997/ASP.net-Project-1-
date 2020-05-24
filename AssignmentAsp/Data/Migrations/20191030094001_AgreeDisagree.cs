using Microsoft.EntityFrameworkCore.Migrations;

namespace AssignmentAsp.Data.Migrations
{
    public partial class AgreeDisagree : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Agree",
                table: "MachineLearningCompaniesFeedback",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Disagree",
                table: "MachineLearningCompaniesFeedback",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Agree",
                table: "MachineLearningCompaniesFeedback");

            migrationBuilder.DropColumn(
                name: "Disagree",
                table: "MachineLearningCompaniesFeedback");
        }
    }
}
