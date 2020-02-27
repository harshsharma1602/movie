using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieCore.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContributorLanguages");

            migrationBuilder.DropTable(
                name: "ContributorTypeLanguages");

            migrationBuilder.DropTable(
                name: "GenreLanguages");

            migrationBuilder.DropTable(
                name: "MovieLanguages");

            migrationBuilder.AddColumn<int>(
                name: "LanguageID",
                table: "Movies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LanguageID",
                table: "Genres",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LanguageID",
                table: "ContributorTypes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LanguageID",
                table: "Contributors",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LanguageID",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "LanguageID",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "LanguageID",
                table: "ContributorTypes");

            migrationBuilder.DropColumn(
                name: "LanguageID",
                table: "Contributors");

            migrationBuilder.CreateTable(
                name: "ContributorLanguages",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ContributorID = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    LanguageID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContributorLanguages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ContributorLanguages_Contributors_ContributorID",
                        column: x => x.ContributorID,
                        principalTable: "Contributors",
                        principalColumn: "ContributorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContributorTypeLanguages",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ContributorTypeID = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    LanguageID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContributorTypeLanguages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ContributorTypeLanguages_ContributorTypes_ContributorTypeID",
                        column: x => x.ContributorTypeID,
                        principalTable: "ContributorTypes",
                        principalColumn: "ContributorTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenreLanguages",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    GenreID = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    LanguageID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreLanguages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GenreLanguages_Genres_GenreID",
                        column: x => x.GenreID,
                        principalTable: "Genres",
                        principalColumn: "GenreID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieLanguages",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    LanguageID = table.Column<int>(nullable: false),
                    MovieID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieLanguages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MovieLanguages_Movies_MovieID",
                        column: x => x.MovieID,
                        principalTable: "Movies",
                        principalColumn: "MovieID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContributorLanguages_ContributorID",
                table: "ContributorLanguages",
                column: "ContributorID");

            migrationBuilder.CreateIndex(
                name: "IX_ContributorTypeLanguages_ContributorTypeID",
                table: "ContributorTypeLanguages",
                column: "ContributorTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_GenreLanguages_GenreID",
                table: "GenreLanguages",
                column: "GenreID");

            migrationBuilder.CreateIndex(
                name: "IX_MovieLanguages_MovieID",
                table: "MovieLanguages",
                column: "MovieID");
        }
    }
}
