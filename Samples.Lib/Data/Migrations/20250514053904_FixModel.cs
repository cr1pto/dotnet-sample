using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Samples.Lib.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DefendantId",
                table: "Cases",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Cases_DefendantId",
                table: "Cases",
                column: "DefendantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Defendants_DefendantId",
                table: "Cases",
                column: "DefendantId",
                principalTable: "Defendants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Defendants_DefendantId",
                table: "Cases");

            migrationBuilder.DropIndex(
                name: "IX_Cases_DefendantId",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "DefendantId",
                table: "Cases");
        }
    }
}
