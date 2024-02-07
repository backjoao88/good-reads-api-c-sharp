using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoodReads.Infrastructure.Persistence.Ef.Migrations
{
    /// <inheritdoc />
    public partial class AddRestrictToIdUserFKInRatings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Rating_tbl_User_IdUser",
                table: "tbl_Rating");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Rating_tbl_User_IdUser",
                table: "tbl_Rating",
                column: "IdUser",
                principalTable: "tbl_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Rating_tbl_User_IdUser",
                table: "tbl_Rating");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Rating_tbl_User_IdUser",
                table: "tbl_Rating",
                column: "IdUser",
                principalTable: "tbl_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
