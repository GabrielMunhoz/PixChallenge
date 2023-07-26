using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PixChallenge_Data.Migrations
{
    /// <inheritdoc />
    public partial class ConfiguringAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankTransaction_AccountHolder_AccountHolderId",
                table: "BankTransaction");

            migrationBuilder.DropForeignKey(
                name: "FK_BankTransaction_AccountHolder_PayeeId",
                table: "BankTransaction");

            migrationBuilder.DropForeignKey(
                name: "FK_BankTransaction_AccountHolder_SenderId",
                table: "BankTransaction");

            migrationBuilder.DropIndex(
                name: "IX_BankTransaction_AccountHolderId",
                table: "BankTransaction");

            migrationBuilder.DropIndex(
                name: "IX_BankTransaction_PayeeId",
                table: "BankTransaction");

            migrationBuilder.DropColumn(
                name: "AccountHolderId",
                table: "BankTransaction");

            migrationBuilder.DropColumn(
                name: "PayeeId",
                table: "BankTransaction");

            migrationBuilder.AddColumn<string>(
                name: "PayeeKey",
                table: "BankTransaction",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_BankTransaction_AccountHolder_SenderId",
                table: "BankTransaction",
                column: "SenderId",
                principalTable: "AccountHolder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankTransaction_AccountHolder_SenderId",
                table: "BankTransaction");

            migrationBuilder.DropColumn(
                name: "PayeeKey",
                table: "BankTransaction");

            migrationBuilder.AddColumn<Guid>(
                name: "AccountHolderId",
                table: "BankTransaction",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PayeeId",
                table: "BankTransaction",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_BankTransaction_AccountHolderId",
                table: "BankTransaction",
                column: "AccountHolderId");

            migrationBuilder.CreateIndex(
                name: "IX_BankTransaction_PayeeId",
                table: "BankTransaction",
                column: "PayeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BankTransaction_AccountHolder_AccountHolderId",
                table: "BankTransaction",
                column: "AccountHolderId",
                principalTable: "AccountHolder",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BankTransaction_AccountHolder_PayeeId",
                table: "BankTransaction",
                column: "PayeeId",
                principalTable: "AccountHolder",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BankTransaction_AccountHolder_SenderId",
                table: "BankTransaction",
                column: "SenderId",
                principalTable: "AccountHolder",
                principalColumn: "Id");
        }
    }
}
