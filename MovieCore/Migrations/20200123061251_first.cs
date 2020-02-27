using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieCore.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "contributors",
                columns: table => new
                {
                    ContributorID = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contributors", x => x.ContributorID);
                });

            migrationBuilder.CreateTable(
                name: "contributortypes",
                columns: table => new
                {
                    ContributorTypeID = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contributortypes", x => x.ContributorTypeID);
                });

            migrationBuilder.CreateTable(
                name: "genres",
                columns: table => new
                {
                    GenreID = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genres", x => x.GenreID);
                });

            migrationBuilder.CreateTable(
                name: "movies",
                columns: table => new
                {
                    MovieID = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movies", x => x.MovieID);
                });

            migrationBuilder.CreateTable(
                name: "contributormanagers",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ContributorID = table.Column<Guid>(nullable: false),
                    ContributorTypeID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contributormanagers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_contributormanagers_contributors_ContributorID",
                        column: x => x.ContributorID,
                        principalTable: "contributors",
                        principalColumn: "ContributorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_contributormanagers_contributortypes_ContributorTypeID",
                        column: x => x.ContributorTypeID,
                        principalTable: "contributortypes",
                        principalColumn: "ContributorTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "moviecontributors",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    MovieID = table.Column<Guid>(nullable: false),
                    ContributorID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_moviecontributors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_moviecontributors_contributors_ContributorID",
                        column: x => x.ContributorID,
                        principalTable: "contributors",
                        principalColumn: "ContributorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_moviecontributors_movies_MovieID",
                        column: x => x.MovieID,
                        principalTable: "movies",
                        principalColumn: "MovieID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "moviegenres",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    MovieID = table.Column<Guid>(nullable: false),
                    GenreID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_moviegenres", x => x.ID);
                    table.ForeignKey(
                        name: "FK_moviegenres_genres_GenreID",
                        column: x => x.GenreID,
                        principalTable: "genres",
                        principalColumn: "GenreID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_moviegenres_movies_MovieID",
                        column: x => x.MovieID,
                        principalTable: "movies",
                        principalColumn: "MovieID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_contributormanagers_ContributorID",
                table: "contributormanagers",
                column: "ContributorID");

            migrationBuilder.CreateIndex(
                name: "IX_contributormanagers_ContributorTypeID",
                table: "contributormanagers",
                column: "ContributorTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_moviecontributors_ContributorID",
                table: "moviecontributors",
                column: "ContributorID");

            migrationBuilder.CreateIndex(
                name: "IX_moviecontributors_MovieID",
                table: "moviecontributors",
                column: "MovieID");

            migrationBuilder.CreateIndex(
                name: "IX_moviegenres_GenreID",
                table: "moviegenres",
                column: "GenreID");

            migrationBuilder.CreateIndex(
                name: "IX_moviegenres_MovieID",
                table: "moviegenres",
                column: "MovieID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contributormanagers");

            migrationBuilder.DropTable(
                name: "moviecontributors");

            migrationBuilder.DropTable(
                name: "moviegenres");

            migrationBuilder.DropTable(
                name: "contributortypes");

            migrationBuilder.DropTable(
                name: "contributors");

            migrationBuilder.DropTable(
                name: "genres");

            migrationBuilder.DropTable(
                name: "movies");
        }
    }
}
