using Microsoft.EntityFrameworkCore.Migrations;

namespace AssignmentAsp.Data.Migrations
{
    public partial class SelectComapny : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Company",
                table: "MachineLearningCompaniesFeedback");

            migrationBuilder.AddColumn<string>(
                name: "SelectCompany",
                table: "MachineLearningCompaniesFeedback",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SelectCompany",
                table: "MachineLearningCompaniesFeedback");

            migrationBuilder.AddColumn<string>(
                name: "Company",
                table: "MachineLearningCompaniesFeedback",
                nullable: false,
                defaultValue: "");
        }
    }
}
