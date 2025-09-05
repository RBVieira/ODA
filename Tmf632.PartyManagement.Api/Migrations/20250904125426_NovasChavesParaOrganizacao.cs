using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tmf632.PartyManagement.Api.Migrations
{
    /// <inheritdoc />
    public partial class NovasChavesParaOrganizacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characteristic_Individuals_IndividualId",
                table: "Characteristic");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactMedium_Individuals_IndividualId",
                table: "ContactMedium");

            migrationBuilder.DropForeignKey(
                name: "FK_RelatedParty_Individuals_IndividualId",
                table: "RelatedParty");

            migrationBuilder.AlterColumn<string>(
                name: "IndividualId",
                table: "RelatedParty",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "IndividualId",
                table: "ContactMedium",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "IndividualId",
                table: "Characteristic",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Characteristic_Individuals_IndividualId",
                table: "Characteristic",
                column: "IndividualId",
                principalTable: "Individuals",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactMedium_Individuals_IndividualId",
                table: "ContactMedium",
                column: "IndividualId",
                principalTable: "Individuals",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RelatedParty_Individuals_IndividualId",
                table: "RelatedParty",
                column: "IndividualId",
                principalTable: "Individuals",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characteristic_Individuals_IndividualId",
                table: "Characteristic");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactMedium_Individuals_IndividualId",
                table: "ContactMedium");

            migrationBuilder.DropForeignKey(
                name: "FK_RelatedParty_Individuals_IndividualId",
                table: "RelatedParty");

            migrationBuilder.AlterColumn<string>(
                name: "IndividualId",
                table: "RelatedParty",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IndividualId",
                table: "ContactMedium",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IndividualId",
                table: "Characteristic",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Characteristic_Individuals_IndividualId",
                table: "Characteristic",
                column: "IndividualId",
                principalTable: "Individuals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactMedium_Individuals_IndividualId",
                table: "ContactMedium",
                column: "IndividualId",
                principalTable: "Individuals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RelatedParty_Individuals_IndividualId",
                table: "RelatedParty",
                column: "IndividualId",
                principalTable: "Individuals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
