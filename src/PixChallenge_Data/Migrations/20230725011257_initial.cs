using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PixChallenge_Data.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountHolder",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KeyType = table.Column<int>(type: "int", nullable: false),
                    ValueKey = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountHolder", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankTransaction",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KeyType = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateProcessed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PayeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankTransaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankTransaction_AccountHolder_PayeeId",
                        column: x => x.PayeeId,
                        principalTable: "AccountHolder",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BankTransaction_AccountHolder_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AccountHolder",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankTransaction_PayeeId",
                table: "BankTransaction",
                column: "PayeeId");

            migrationBuilder.CreateIndex(
                name: "IX_BankTransaction_SenderId",
                table: "BankTransaction",
                column: "SenderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankTransaction");

            migrationBuilder.DropTable(
                name: "AccountHolder");
        }
    }
}
