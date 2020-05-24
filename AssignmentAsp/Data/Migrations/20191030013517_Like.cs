using Microsoft.EntityFrameworkCore.Migrations;

namespace AssignmentAsp.Data.Migrations
{
    public partial class Like : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Like",
                table: "MachineLearningCompaniesFeedback",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Like",
                table: "MachineLearningCompaniesFeedback");
        }
    }
}
