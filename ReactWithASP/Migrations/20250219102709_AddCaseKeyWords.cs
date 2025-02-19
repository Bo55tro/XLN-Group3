using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReactWithASP.Migrations
{
    /// <inheritdoc />
    public partial class AddCaseKeyWords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropForeignKey(
                name: "FK_Details_Reasons_ReasonId",
                table: "Details");

            migrationBuilder.DropForeignKey(
                name: "FK_Reasons_Categories_CategoryId",
                table: "Reasons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reasons",
                table: "Reasons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Details",
                table: "Details");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Reasons",
                newName: "Reason");

            migrationBuilder.RenameTable(
                name: "Details",
                newName: "Detail");

            migrationBuilder.RenameTable(
                name: "Clients",
                newName: "Client");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

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

            migrationBuilder.RenameIndex(
                name: "IX_Reasons_CategoryId",
                table: "Reason",
                newName: "IX_Reason_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Details_ReasonId",
                table: "Detail",
                newName: "IX_Detail_ReasonId");

            migrationBuilder.AddColumn<string>(
                name: "caseKeyWords",
                table: "Cases",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reason",
                table: "Reason",
                column: "ReasonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Detail",
                table: "Detail",
                column: "DetailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Client",
                table: "Client",
                column: "clientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "categoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Category_CategoryId",
                table: "Cases",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "categoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Client_ClientId",
                table: "Cases",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "clientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Detail_DetailId",
                table: "Cases",
                column: "DetailId",
                principalTable: "Detail",
                principalColumn: "DetailId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Reason_ReasonId",
                table: "Cases",
                column: "ReasonId",
                principalTable: "Reason",
                principalColumn: "ReasonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Detail_Reason_ReasonId",
                table: "Detail",
                column: "ReasonId",
                principalTable: "Reason",
                principalColumn: "ReasonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reason_Category_CategoryId",
                table: "Reason",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "categoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Category_CategoryId",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Client_ClientId",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Detail_DetailId",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Reason_ReasonId",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_Detail_Reason_ReasonId",
                table: "Detail");

            migrationBuilder.DropForeignKey(
                name: "FK_Reason_Category_CategoryId",
                table: "Reason");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reason",
                table: "Reason");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Detail",
                table: "Detail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Client",
                table: "Client");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "caseKeyWords",
                table: "Cases");

            migrationBuilder.RenameTable(
                name: "Reason",
                newName: "Reasons");

            migrationBuilder.RenameTable(
                name: "Detail",
                newName: "Details");

            migrationBuilder.RenameTable(
                name: "Client",
                newName: "Clients");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

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

            migrationBuilder.RenameIndex(
                name: "IX_Reason_CategoryId",
                table: "Reasons",
                newName: "IX_Reasons_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Detail_ReasonId",
                table: "Details",
                newName: "IX_Details_ReasonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reasons",
                table: "Reasons",
                column: "ReasonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Details",
                table: "Details",
                column: "DetailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                column: "clientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "categoryId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Details_Reasons_ReasonId",
                table: "Details",
                column: "ReasonId",
                principalTable: "Reasons",
                principalColumn: "ReasonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reasons_Categories_CategoryId",
                table: "Reasons",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "categoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
