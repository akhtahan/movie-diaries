using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class reviewsDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Movies_MovieId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_WatchedListDB_WatchedMovieId",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Review",
                table: "Review");

            migrationBuilder.RenameTable(
                name: "Review",
                newName: "ReviewsDB");

            migrationBuilder.RenameIndex(
                name: "IX_Review_WatchedMovieId",
                table: "ReviewsDB",
                newName: "IX_ReviewsDB_WatchedMovieId");

            migrationBuilder.RenameIndex(
                name: "IX_Review_MovieId",
                table: "ReviewsDB",
                newName: "IX_ReviewsDB_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReviewsDB",
                table: "ReviewsDB",
                column: "ReviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewsDB_Movies_MovieId",
                table: "ReviewsDB",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewsDB_WatchedListDB_WatchedMovieId",
                table: "ReviewsDB",
                column: "WatchedMovieId",
                principalTable: "WatchedListDB",
                principalColumn: "WatchedMovieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReviewsDB_Movies_MovieId",
                table: "ReviewsDB");

            migrationBuilder.DropForeignKey(
                name: "FK_ReviewsDB_WatchedListDB_WatchedMovieId",
                table: "ReviewsDB");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReviewsDB",
                table: "ReviewsDB");

            migrationBuilder.RenameTable(
                name: "ReviewsDB",
                newName: "Review");

            migrationBuilder.RenameIndex(
                name: "IX_ReviewsDB_WatchedMovieId",
                table: "Review",
                newName: "IX_Review_WatchedMovieId");

            migrationBuilder.RenameIndex(
                name: "IX_ReviewsDB_MovieId",
                table: "Review",
                newName: "IX_Review_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Review",
                table: "Review",
                column: "ReviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Movies_MovieId",
                table: "Review",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_WatchedListDB_WatchedMovieId",
                table: "Review",
                column: "WatchedMovieId",
                principalTable: "WatchedListDB",
                principalColumn: "WatchedMovieId");
        }
    }
}
