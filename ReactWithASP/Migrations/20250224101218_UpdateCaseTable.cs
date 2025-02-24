using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReactWithASP.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCaseTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "caseTitle",
                table: "Cases",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "caseTitle",
                table: "Cases");
        }
    }
}
