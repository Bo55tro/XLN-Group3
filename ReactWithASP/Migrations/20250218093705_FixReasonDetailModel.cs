using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReactWithASP.Migrations
{
    /// <inheritdoc />
    public partial class FixReasonDetailModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Categories_CategoryId",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Clients_ClientId",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Details_DetailId",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Reasons_ReasonId",
                table: "Cases");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Reasons",
                newName: "ReasonName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Reasons",
                newName: "ReasonId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Details",
                newName: "DetailName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Details",
                newName: "DetailId");

            migrationBuilder.RenameColumn(
                name: "ClientName",
                table: "Clients",
                newName: "clientName");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Clients",
                newName: "clientId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Categories",
                newName: "categoryName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Categories",
                newName: "categoryId");

            migrationBuilder.RenameColumn(
                name: "ReasonId",
                table: "Cases",
                newName: "reasonId");

            migrationBuilder.RenameColumn(
                name: "DetailId",
                table: "Cases",
                newName: "detailId");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Cases",
                newName: "clientId");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Cases",
                newName: "categoryId");

            migrationBuilder.RenameColumn(
                name: "CaseId",
                table: "Cases",
                newName: "caseId");

            migrationBuilder.RenameColumn(
                name: "Comments",
                table: "Cases",
                newName: "caseStatus");

            migrationBuilder.RenameIndex(
                name: "IX_Cases_ReasonId",
                table: "Cases",
                newName: "IX_Cases_reasonId");

            migrationBuilder.RenameIndex(
                name: "IX_Cases_DetailId",
                table: "Cases",
                newName: "IX_Cases_detailId");

            migrationBuilder.RenameIndex(
                name: "IX_Cases_ClientId",
                table: "Cases",
                newName: "IX_Cases_clientId");

            migrationBuilder.RenameIndex(
                name: "IX_Cases_CategoryId",
                table: "Cases",
                newName: "IX_Cases_categoryId");

            migrationBuilder.AddColumn<int>(
                name: "agentId",
                table: "Cases",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "caseComments",
                table: "Cases",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "caseDate",
                table: "Cases",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "caseNotes",
                table: "Cases",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Categories_categoryId",
                table: "Cases",
                column: "categoryId",
                principalTable: "Categories",
                principalColumn: "categoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Clients_clientId",
                table: "Cases",
                column: "clientId",
                principalTable: "Clients",
                principalColumn: "clientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Details_detailId",
                table: "Cases",
                column: "detailId",
                principalTable: "Details",
                principalColumn: "DetailId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Reasons_reasonId",
                table: "Cases",
                column: "reasonId",
                principalTable: "Reasons",
                principalColumn: "ReasonId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Categories_categoryId",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Clients_clientId",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Details_detailId",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Reasons_reasonId",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "agentId",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "caseComments",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "caseDate",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "caseNotes",
                table: "Cases");

            migrationBuilder.RenameColumn(
                name: "ReasonName",
                table: "Reasons",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ReasonId",
                table: "Reasons",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "DetailName",
                table: "Details",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "DetailId",
                table: "Details",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "clientName",
                table: "Clients",
                newName: "ClientName");

            migrationBuilder.RenameColumn(
                name: "clientId",
                table: "Clients",
                newName: "ClientId");

            migrationBuilder.RenameColumn(
                name: "categoryName",
                table: "Categories",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "categoryId",
                table: "Categories",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "reasonId",
                table: "Cases",
                newName: "ReasonId");

            migrationBuilder.RenameColumn(
                name: "detailId",
                table: "Cases",
                newName: "DetailId");

            migrationBuilder.RenameColumn(
                name: "clientId",
                table: "Cases",
                newName: "ClientId");

            migrationBuilder.RenameColumn(
                name: "categoryId",
                table: "Cases",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "caseId",
                table: "Cases",
                newName: "CaseId");

            migrationBuilder.RenameColumn(
                name: "caseStatus",
                table: "Cases",
                newName: "Comments");

            migrationBuilder.RenameIndex(
                name: "IX_Cases_reasonId",
                table: "Cases",
                newName: "IX_Cases_ReasonId");

            migrationBuilder.RenameIndex(
                name: "IX_Cases_detailId",
                table: "Cases",
                newName: "IX_Cases_DetailId");

            migrationBuilder.RenameIndex(
                name: "IX_Cases_clientId",
                table: "Cases",
                newName: "IX_Cases_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Cases_categoryId",
                table: "Cases",
                newName: "IX_Cases_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Categories_CategoryId",
                table: "Cases",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Clients_ClientId",
                table: "Cases",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Details_DetailId",
                table: "Cases",
                column: "DetailId",
                principalTable: "Details",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Reasons_ReasonId",
                table: "Cases",
                column: "ReasonId",
                principalTable: "Reasons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
