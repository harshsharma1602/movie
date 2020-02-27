using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieCore.Migrations
{
    public partial class Final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_MovieContributorTypes_MovieID",
                table: "MovieContributorTypes",
                column: "MovieID");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieContributorTypes_Movies_MovieID",
                table: "MovieContributorTypes",
                column: "MovieID",
                principalTable: "Movies",
                principalColumn: "MovieID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieContributorTypes_Movies_MovieID",
                table: "MovieContributorTypes");

            migrationBuilder.DropIndex(
                name: "IX_MovieContributorTypes_MovieID",
                table: "MovieContributorTypes");
        }
    }
}
