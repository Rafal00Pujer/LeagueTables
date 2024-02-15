using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeagueTables.Migrations
{
    /// <inheritdoc />
    public partial class AddedTableEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamTableScore_LeagueSeason_SeasonId",
                table: "TeamTableScore");

            migrationBuilder.RenameColumn(
                name: "SeasonId",
                table: "TeamTableScore",
                newName: "TableId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamTableScore_SeasonId",
                table: "TeamTableScore",
                newName: "IX_TeamTableScore_TableId");

            migrationBuilder.CreateTable(
                name: "Table",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeasonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Table_LeagueSeason_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "LeagueSeason",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Table_SeasonId",
                table: "Table",
                column: "SeasonId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamTableScore_Table_TableId",
                table: "TeamTableScore",
                column: "TableId",
                principalTable: "Table",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamTableScore_Table_TableId",
                table: "TeamTableScore");

            migrationBuilder.DropTable(
                name: "Table");

            migrationBuilder.RenameColumn(
                name: "TableId",
                table: "TeamTableScore",
                newName: "SeasonId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamTableScore_TableId",
                table: "TeamTableScore",
                newName: "IX_TeamTableScore_SeasonId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamTableScore_LeagueSeason_SeasonId",
                table: "TeamTableScore",
                column: "SeasonId",
                principalTable: "LeagueSeason",
                principalColumn: "Id");
        }
    }
}
