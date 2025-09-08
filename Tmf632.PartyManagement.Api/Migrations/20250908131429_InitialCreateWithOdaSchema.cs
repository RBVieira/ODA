using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tmf632.PartyManagement.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateWithOdaSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ODA");

            migrationBuilder.RenameTable(
                name: "RelatedParty",
                newName: "RelatedParty",
                newSchema: "ODA");

            migrationBuilder.RenameTable(
                name: "Organizations",
                newName: "Organizations",
                newSchema: "ODA");

            migrationBuilder.RenameTable(
                name: "Individuals",
                newName: "Individuals",
                newSchema: "ODA");

            migrationBuilder.RenameTable(
                name: "ContactMedium",
                newName: "ContactMedium",
                newSchema: "ODA");

            migrationBuilder.RenameTable(
                name: "Characteristic",
                newName: "Characteristic",
                newSchema: "ODA");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "RelatedParty",
                schema: "ODA",
                newName: "RelatedParty");

            migrationBuilder.RenameTable(
                name: "Organizations",
                schema: "ODA",
                newName: "Organizations");

            migrationBuilder.RenameTable(
                name: "Individuals",
                schema: "ODA",
                newName: "Individuals");

            migrationBuilder.RenameTable(
                name: "ContactMedium",
                schema: "ODA",
                newName: "ContactMedium");

            migrationBuilder.RenameTable(
                name: "Characteristic",
                schema: "ODA",
                newName: "Characteristic");
        }
    }
}
