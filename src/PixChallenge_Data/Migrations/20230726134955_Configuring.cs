using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PixChallenge_Data.Migrations
{
    /// <inheritdoc />
    public partial class Configuring : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AccountHolderId",
                table: "BankTransaction",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BankTransaction_AccountHolderId",
                table: "BankTransaction",
                column: "AccountHolderId");

            migrationBuilder.AddForeignKey(
                name: "FK_BankTransaction_AccountHolder_AccountHolderId",
                table: "BankTransaction",
                column: "AccountHolderId",
                principalTable: "AccountHolder",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankTransaction_AccountHolder_AccountHolderId",
                table: "BankTransaction");

            migrationBuilder.DropIndex(
                name: "IX_BankTransaction_AccountHolderId",
                table: "BankTransaction");

            migrationBuilder.DropColumn(
                name: "AccountHolderId",
                table: "BankTransaction");
        }
    }
}
