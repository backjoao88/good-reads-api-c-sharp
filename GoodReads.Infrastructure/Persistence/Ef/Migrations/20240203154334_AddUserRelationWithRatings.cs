using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoodReads.Infrastructure.Persistence.Ef.Migrations
{
    /// <inheritdoc />
    public partial class AddUserRelationWithRatings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdUser",
                table: "tbl_Rating",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Rating_IdUser",
                table: "tbl_Rating",
                column: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Rating_tbl_User_IdUser",
                table: "tbl_Rating",
                column: "IdUser",
                principalTable: "tbl_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Rating_tbl_User_IdUser",
                table: "tbl_Rating");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Rating_IdUser",
                table: "tbl_Rating");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "tbl_Rating");
        }
    }
}
