using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RouletteAPI.Migrations
{
    /// <inheritdoc />
    public partial class firstmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bet",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    BetTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DatePlaced = table.Column<DateTime>(type: "TEXT", nullable: false),
                    RoundId = table.Column<Guid>(type: "TEXT", nullable: false),
                    BetAmount = table.Column<double>(type: "REAL", nullable: false),
                    BetPayout = table.Column<double>(type: "REAL", nullable: false),
                    ChosenNumbers = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BetType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NumbersInBet = table.Column<string>(type: "TEXT", nullable: true),
                    BetRate = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BetType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Round",
                columns: table => new
                {
                    RoundId = table.Column<Guid>(type: "TEXT", nullable: false),
                    WinningNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    RoundCreated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Round", x => x.RoundId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bet");

            migrationBuilder.DropTable(
                name: "BetType");

            migrationBuilder.DropTable(
                name: "Round");
        }
    }
}
