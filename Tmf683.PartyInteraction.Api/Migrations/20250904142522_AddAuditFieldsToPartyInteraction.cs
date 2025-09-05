using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tmf683.PartyInteraction.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddAuditFieldsToPartyInteraction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateDate",
                table: "PartyInteractions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastUpdateDate",
                table: "PartyInteractions");
        }
    }
}
