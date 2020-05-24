using Microsoft.EntityFrameworkCore.Migrations;

namespace AssignmentAsp.Data.Migrations
{
    public partial class MessageContents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MessageContent",
                table: "MachineLearningCompaniesFeedback",
                nullable: true,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MessageContent",
                table: "MachineLearningCompaniesFeedback",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
