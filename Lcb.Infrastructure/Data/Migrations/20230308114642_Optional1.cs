using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lcb.Infrastructure.Data.Migrations
{
    public partial class Optional1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostcardImage_Postcards_PostcardId",
                table: "PostcardImage");

            migrationBuilder.DropForeignKey(
                name: "FK_Postcards_Users_UserId",
                table: "Postcards");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Postcards",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_PostcardImage_Postcards_PostcardId",
                table: "PostcardImage",
                column: "PostcardId",
                principalTable: "Postcards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Postcards_Users_UserId",
                table: "Postcards",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostcardImage_Postcards_PostcardId",
                table: "PostcardImage");

            migrationBuilder.DropForeignKey(
                name: "FK_Postcards_Users_UserId",
                table: "Postcards");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Postcards",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PostcardImage_Postcards_PostcardId",
                table: "PostcardImage",
                column: "PostcardId",
                principalTable: "Postcards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Postcards_Users_UserId",
                table: "Postcards",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
