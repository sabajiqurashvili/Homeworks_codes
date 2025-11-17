using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Domain.Migrations
{
    /// <inheritdoc />
    public partial class updateBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adresses_Persons_PersonId",
                table: "Adresses");

            migrationBuilder.DropIndex(
                name: "IX_Adresses_PersonId",
                table: "Adresses");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Adresses");

            migrationBuilder.AddColumn<int>(
                name: "AdressId",
                table: "Persons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_AdressId",
                table: "Persons",
                column: "AdressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Adresses_AdressId",
                table: "Persons",
                column: "AdressId",
                principalTable: "Adresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Adresses_AdressId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_AdressId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "AdressId",
                table: "Persons");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Adresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Adresses_PersonId",
                table: "Adresses",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adresses_Persons_PersonId",
                table: "Adresses",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
