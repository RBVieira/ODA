using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tmf632.PartyManagement.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddIsHeadOfficeAsBooleanToOrganization2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsHeadOffice",
                table: "Organizations",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IsHeadOffice",
                table: "Organizations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
