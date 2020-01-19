using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AcuTestRestAPI.Migrations
{
    public partial class newmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountData");

            migrationBuilder.DropTable(
                name: "FavoriteResturants");

            migrationBuilder.DropTable(
                name: "FavouriteDeals");

            migrationBuilder.DropColumn(
                name: "AccountNumber",
                table: "UserProfile");

            migrationBuilder.CreateTable(
                name: "ComparedFiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<string>(nullable: true),
                    FirstStudentName = table.Column<string>(nullable: true),
                    SecondStudentName = table.Column<string>(nullable: true),
                    FirstStudentFile = table.Column<string>(nullable: true),
                    SecondStudentFile = table.Column<string>(nullable: true),
                    PercentageSimilarity = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComparedFiles", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComparedFiles");

            migrationBuilder.AddColumn<int>(
                name: "AccountNumber",
                table: "UserProfile",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AccountData",
                columns: table => new
                {
                    guid = table.Column<Guid>(nullable: false),
                    AccountNumber = table.Column<int>(nullable: false),
                    CurrentBalance = table.Column<double>(nullable: false),
                    LedgerBalance = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountData", x => x.guid);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteResturants",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ResturantId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteResturants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FavouriteDeals",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DealId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouriteDeals", x => x.Id);
                });
        }
    }
}
