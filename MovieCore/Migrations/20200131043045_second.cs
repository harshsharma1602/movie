using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieCore.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contributormanagers_contributors_ContributorID",
                table: "contributormanagers");

            migrationBuilder.DropForeignKey(
                name: "FK_contributormanagers_contributortypes_ContributorTypeID",
                table: "contributormanagers");

            migrationBuilder.DropForeignKey(
                name: "FK_moviecontributors_contributors_ContributorID",
                table: "moviecontributors");

            migrationBuilder.DropForeignKey(
                name: "FK_moviecontributors_movies_MovieID",
                table: "moviecontributors");

            migrationBuilder.DropForeignKey(
                name: "FK_moviegenres_genres_GenreID",
                table: "moviegenres");

            migrationBuilder.DropForeignKey(
                name: "FK_moviegenres_movies_MovieID",
                table: "moviegenres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_movies",
                table: "movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_moviegenres",
                table: "moviegenres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_moviecontributors",
                table: "moviecontributors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_genres",
                table: "genres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_contributortypes",
                table: "contributortypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_contributors",
                table: "contributors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_contributormanagers",
                table: "contributormanagers");

            migrationBuilder.RenameTable(
                name: "movies",
                newName: "Movies");

            migrationBuilder.RenameTable(
                name: "moviegenres",
                newName: "MovieGenres");

            migrationBuilder.RenameTable(
                name: "moviecontributors",
                newName: "MovieContributors");

            migrationBuilder.RenameTable(
                name: "genres",
                newName: "Genres");

            migrationBuilder.RenameTable(
                name: "contributortypes",
                newName: "ContributorTypes");

            migrationBuilder.RenameTable(
                name: "contributors",
                newName: "Contributors");

            migrationBuilder.RenameTable(
                name: "contributormanagers",
                newName: "ContributorManagers");

            migrationBuilder.RenameIndex(
                name: "IX_moviegenres_MovieID",
                table: "MovieGenres",
                newName: "IX_MovieGenres_MovieID");

            migrationBuilder.RenameIndex(
                name: "IX_moviegenres_GenreID",
                table: "MovieGenres",
                newName: "IX_MovieGenres_GenreID");

            migrationBuilder.RenameIndex(
                name: "IX_moviecontributors_MovieID",
                table: "MovieContributors",
                newName: "IX_MovieContributors_MovieID");

            migrationBuilder.RenameIndex(
                name: "IX_moviecontributors_ContributorID",
                table: "MovieContributors",
                newName: "IX_MovieContributors_ContributorID");

            migrationBuilder.RenameIndex(
                name: "IX_contributormanagers_ContributorTypeID",
                table: "ContributorManagers",
                newName: "IX_ContributorManagers_ContributorTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_contributormanagers_ContributorID",
                table: "ContributorManagers",
                newName: "IX_ContributorManagers_ContributorID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movies",
                table: "Movies",
                column: "MovieID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieGenres",
                table: "MovieGenres",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieContributors",
                table: "MovieContributors",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genres",
                table: "Genres",
                column: "GenreID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContributorTypes",
                table: "ContributorTypes",
                column: "ContributorTypeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contributors",
                table: "Contributors",
                column: "ContributorID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContributorManagers",
                table: "ContributorManagers",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "ContributorLanguages",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ContributorID = table.Column<Guid>(nullable: false),
                    LanguageID = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
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
                    LanguageID = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
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
                    GenreID = table.Column<Guid>(nullable: false),
                    LanguageID = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
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
                    MovieID = table.Column<Guid>(nullable: false),
                    LanguageID = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
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

            migrationBuilder.AddForeignKey(
                name: "FK_ContributorManagers_Contributors_ContributorID",
                table: "ContributorManagers",
                column: "ContributorID",
                principalTable: "Contributors",
                principalColumn: "ContributorID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContributorManagers_ContributorTypes_ContributorTypeID",
                table: "ContributorManagers",
                column: "ContributorTypeID",
                principalTable: "ContributorTypes",
                principalColumn: "ContributorTypeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieContributors_Contributors_ContributorID",
                table: "MovieContributors",
                column: "ContributorID",
                principalTable: "Contributors",
                principalColumn: "ContributorID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieContributors_Movies_MovieID",
                table: "MovieContributors",
                column: "MovieID",
                principalTable: "Movies",
                principalColumn: "MovieID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieGenres_Genres_GenreID",
                table: "MovieGenres",
                column: "GenreID",
                principalTable: "Genres",
                principalColumn: "GenreID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieGenres_Movies_MovieID",
                table: "MovieGenres",
                column: "MovieID",
                principalTable: "Movies",
                principalColumn: "MovieID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContributorManagers_Contributors_ContributorID",
                table: "ContributorManagers");

            migrationBuilder.DropForeignKey(
                name: "FK_ContributorManagers_ContributorTypes_ContributorTypeID",
                table: "ContributorManagers");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieContributors_Contributors_ContributorID",
                table: "MovieContributors");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieContributors_Movies_MovieID",
                table: "MovieContributors");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieGenres_Genres_GenreID",
                table: "MovieGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieGenres_Movies_MovieID",
                table: "MovieGenres");

            migrationBuilder.DropTable(
                name: "ContributorLanguages");

            migrationBuilder.DropTable(
                name: "ContributorTypeLanguages");

            migrationBuilder.DropTable(
                name: "GenreLanguages");

            migrationBuilder.DropTable(
                name: "MovieLanguages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movies",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieGenres",
                table: "MovieGenres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieContributors",
                table: "MovieContributors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genres",
                table: "Genres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContributorTypes",
                table: "ContributorTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contributors",
                table: "Contributors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContributorManagers",
                table: "ContributorManagers");

            migrationBuilder.RenameTable(
                name: "Movies",
                newName: "movies");

            migrationBuilder.RenameTable(
                name: "MovieGenres",
                newName: "moviegenres");

            migrationBuilder.RenameTable(
                name: "MovieContributors",
                newName: "moviecontributors");

            migrationBuilder.RenameTable(
                name: "Genres",
                newName: "genres");

            migrationBuilder.RenameTable(
                name: "ContributorTypes",
                newName: "contributortypes");

            migrationBuilder.RenameTable(
                name: "Contributors",
                newName: "contributors");

            migrationBuilder.RenameTable(
                name: "ContributorManagers",
                newName: "contributormanagers");

            migrationBuilder.RenameIndex(
                name: "IX_MovieGenres_MovieID",
                table: "moviegenres",
                newName: "IX_moviegenres_MovieID");

            migrationBuilder.RenameIndex(
                name: "IX_MovieGenres_GenreID",
                table: "moviegenres",
                newName: "IX_moviegenres_GenreID");

            migrationBuilder.RenameIndex(
                name: "IX_MovieContributors_MovieID",
                table: "moviecontributors",
                newName: "IX_moviecontributors_MovieID");

            migrationBuilder.RenameIndex(
                name: "IX_MovieContributors_ContributorID",
                table: "moviecontributors",
                newName: "IX_moviecontributors_ContributorID");

            migrationBuilder.RenameIndex(
                name: "IX_ContributorManagers_ContributorTypeID",
                table: "contributormanagers",
                newName: "IX_contributormanagers_ContributorTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_ContributorManagers_ContributorID",
                table: "contributormanagers",
                newName: "IX_contributormanagers_ContributorID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_movies",
                table: "movies",
                column: "MovieID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_moviegenres",
                table: "moviegenres",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_moviecontributors",
                table: "moviecontributors",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_genres",
                table: "genres",
                column: "GenreID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_contributortypes",
                table: "contributortypes",
                column: "ContributorTypeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_contributors",
                table: "contributors",
                column: "ContributorID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_contributormanagers",
                table: "contributormanagers",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_contributormanagers_contributors_ContributorID",
                table: "contributormanagers",
                column: "ContributorID",
                principalTable: "contributors",
                principalColumn: "ContributorID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_contributormanagers_contributortypes_ContributorTypeID",
                table: "contributormanagers",
                column: "ContributorTypeID",
                principalTable: "contributortypes",
                principalColumn: "ContributorTypeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_moviecontributors_contributors_ContributorID",
                table: "moviecontributors",
                column: "ContributorID",
                principalTable: "contributors",
                principalColumn: "ContributorID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_moviecontributors_movies_MovieID",
                table: "moviecontributors",
                column: "MovieID",
                principalTable: "movies",
                principalColumn: "MovieID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_moviegenres_genres_GenreID",
                table: "moviegenres",
                column: "GenreID",
                principalTable: "genres",
                principalColumn: "GenreID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_moviegenres_movies_MovieID",
                table: "moviegenres",
                column: "MovieID",
                principalTable: "movies",
                principalColumn: "MovieID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
