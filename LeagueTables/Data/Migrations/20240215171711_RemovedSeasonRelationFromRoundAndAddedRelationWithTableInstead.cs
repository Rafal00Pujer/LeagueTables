using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeagueTables.Migrations
{
    /// <inheritdoc />
    public partial class RemovedSeasonRelationFromRoundAndAddedRelationWithTableInstead : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Round_LeagueSeason_SeasonId",
                table: "Round");

            migrationBuilder.RenameColumn(
                name: "SeasonId",
                table: "Round",
                newName: "TableId");

            migrationBuilder.RenameIndex(
                name: "IX_Round_SeasonId",
                table: "Round",
                newName: "IX_Round_TableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Round_Table_TableId",
                table: "Round",
                column: "TableId",
                principalTable: "Table",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Round_Table_TableId",
                table: "Round");

            migrationBuilder.RenameColumn(
                name: "TableId",
                table: "Round",
                newName: "SeasonId");

            migrationBuilder.RenameIndex(
                name: "IX_Round_TableId",
                table: "Round",
                newName: "IX_Round_SeasonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Round_LeagueSeason_SeasonId",
                table: "Round",
                column: "SeasonId",
                principalTable: "LeagueSeason",
                principalColumn: "Id");
        }
    }
}
