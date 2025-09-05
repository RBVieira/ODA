using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tmf683.PartyInteraction.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PartyInteractions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InteractionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Channel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartyInteractions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RelatedPartyRefs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PartyId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PartyInteractionId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PartyInteractId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelatedPartyRefs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RelatedPartyRefs_PartyInteractions_PartyInteractId",
                        column: x => x.PartyInteractId,
                        principalTable: "PartyInteractions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RelatedPartyRefs_PartyInteractId",
                table: "RelatedPartyRefs",
                column: "PartyInteractId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RelatedPartyRefs");

            migrationBuilder.DropTable(
                name: "PartyInteractions");
        }
    }
}
