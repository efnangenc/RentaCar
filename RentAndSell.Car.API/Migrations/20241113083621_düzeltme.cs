using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentAndSell.Car.API.Migrations
{
    /// <inheritdoc />
    public partial class düzeltme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ArabaTarihce",
                table: "ArabaTarihce");

            migrationBuilder.DropColumn(
                name: "ArabaId",
                table: "Arabalar");

            migrationBuilder.RenameTable(
                name: "ArabaTarihce",
                newName: "ArabaTarihcesi");

            migrationBuilder.AddColumn<int>(
                name: "ArabaId",
                table: "ArabaTarihcesi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArabaTarihcesi",
                table: "ArabaTarihcesi",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ArabaTarihcesi",
                table: "ArabaTarihcesi");

            migrationBuilder.DropColumn(
                name: "ArabaId",
                table: "ArabaTarihcesi");

            migrationBuilder.RenameTable(
                name: "ArabaTarihcesi",
                newName: "ArabaTarihce");

            migrationBuilder.AddColumn<int>(
                name: "ArabaId",
                table: "Arabalar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArabaTarihce",
                table: "ArabaTarihce",
                column: "Id");
        }
    }
}
