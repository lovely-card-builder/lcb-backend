using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lcb.Infrastructure.Data.Migrations
{
    public partial class Updates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Postcards");

            migrationBuilder.CreateTable(
                name: "PostcardImage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    PostcardId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostcardImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostcardImage_Postcards_PostcardId",
                        column: x => x.PostcardId,
                        principalTable: "Postcards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostcardImage_PostcardId",
                table: "PostcardImage",
                column: "PostcardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostcardImage");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Postcards",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
