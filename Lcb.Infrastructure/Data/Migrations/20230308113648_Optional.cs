using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lcb.Infrastructure.Data.Migrations
{
    public partial class Optional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostcardImage_Postcards_PostcardId",
                table: "PostcardImage");

            migrationBuilder.AddForeignKey(
                name: "FK_PostcardImage_Postcards_PostcardId",
                table: "PostcardImage",
                column: "PostcardId",
                principalTable: "Postcards",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostcardImage_Postcards_PostcardId",
                table: "PostcardImage");

            migrationBuilder.AddForeignKey(
                name: "FK_PostcardImage_Postcards_PostcardId",
                table: "PostcardImage",
                column: "PostcardId",
                principalTable: "Postcards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
