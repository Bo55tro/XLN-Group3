using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReactWithASP.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAgents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agent");

            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    agentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    agentName = table.Column<string>(type: "TEXT", nullable: false),
                    agentUsername = table.Column<string>(type: "TEXT", nullable: false),
                    agentPassword = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.agentId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agents");

            migrationBuilder.CreateTable(
                name: "Agent",
                columns: table => new
                {
                    agentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    agentName = table.Column<string>(type: "TEXT", nullable: false),
                    agentPassword = table.Column<string>(type: "TEXT", nullable: false),
                    agentUsername = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agent", x => x.agentId);
                });
        }
    }
}
