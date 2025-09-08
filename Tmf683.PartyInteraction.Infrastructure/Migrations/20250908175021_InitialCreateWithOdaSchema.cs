using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tmf683.PartyInteraction.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateWithOdaSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ODA");

            migrationBuilder.CreateTable(
                name: "PartyInteractions",
                schema: "ODA",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Href = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    baseType = table.Column<string>(name: "@baseType", type: "nvarchar(max)", nullable: true),
                    type = table.Column<string>(name: "@type", type: "nvarchar(max)", nullable: true),
                    schemaLocation = table.Column<string>(name: "@schemaLocation", type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InteractionStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InteractionEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartyInteractions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExternalIdentifiers",
                schema: "ODA",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    baseType = table.Column<string>(name: "@baseType", type: "nvarchar(max)", nullable: true),
                    type = table.Column<string>(name: "@type", type: "nvarchar(max)", nullable: true),
                    schemaLocation = table.Column<string>(name: "@schemaLocation", type: "nvarchar(max)", nullable: true),
                    ExternalIdValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExternalIdType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartyInteractionId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalIdentifiers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExternalIdentifiers_PartyInteractions_PartyInteractionId",
                        column: x => x.PartyInteractionId,
                        principalSchema: "ODA",
                        principalTable: "PartyInteractions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InteractionItems",
                schema: "ODA",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    baseType = table.Column<string>(name: "@baseType", type: "nvarchar(max)", nullable: true),
                    type = table.Column<string>(name: "@type", type: "nvarchar(max)", nullable: true),
                    schemaLocation = table.Column<string>(name: "@schemaLocation", type: "nvarchar(max)", nullable: true),
                    ItemType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PartyInteractionId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InteractionItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InteractionItems_PartyInteractions_PartyInteractionId",
                        column: x => x.PartyInteractionId,
                        principalSchema: "ODA",
                        principalTable: "PartyInteractions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InteractionRelationships",
                schema: "ODA",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    baseType = table.Column<string>(name: "@baseType", type: "nvarchar(max)", nullable: true),
                    type = table.Column<string>(name: "@type", type: "nvarchar(max)", nullable: true),
                    schemaLocation = table.Column<string>(name: "@schemaLocation", type: "nvarchar(max)", nullable: true),
                    referredType = table.Column<string>(name: "@referredType", type: "nvarchar(max)", nullable: true),
                    Href = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RelationshipType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TargetInteractionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartyInteractionId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InteractionRelationships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InteractionRelationships_PartyInteractions_PartyInteractionId",
                        column: x => x.PartyInteractionId,
                        principalSchema: "ODA",
                        principalTable: "PartyInteractions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RelatedChannels",
                schema: "ODA",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    baseType = table.Column<string>(name: "@baseType", type: "nvarchar(max)", nullable: true),
                    type = table.Column<string>(name: "@type", type: "nvarchar(max)", nullable: true),
                    schemaLocation = table.Column<string>(name: "@schemaLocation", type: "nvarchar(max)", nullable: true),
                    referredType = table.Column<string>(name: "@referredType", type: "nvarchar(max)", nullable: true),
                    Href = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartyInteractionId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelatedChannels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RelatedChannels_PartyInteractions_PartyInteractionId",
                        column: x => x.PartyInteractionId,
                        principalSchema: "ODA",
                        principalTable: "PartyInteractions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attachments",
                schema: "ODA",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    baseType = table.Column<string>(name: "@baseType", type: "nvarchar(max)", nullable: true),
                    type = table.Column<string>(name: "@type", type: "nvarchar(max)", nullable: true),
                    schemaLocation = table.Column<string>(name: "@schemaLocation", type: "nvarchar(max)", nullable: true),
                    referredType = table.Column<string>(name: "@referredType", type: "nvarchar(max)", nullable: true),
                    Href = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MimeType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<long>(type: "bigint", nullable: true),
                    ValidForStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValidForEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PartyInteractionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InteractionItemId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attachments_InteractionItems_InteractionItemId",
                        column: x => x.InteractionItemId,
                        principalSchema: "ODA",
                        principalTable: "InteractionItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Attachments_PartyInteractions_PartyInteractionId",
                        column: x => x.PartyInteractionId,
                        principalSchema: "ODA",
                        principalTable: "PartyInteractions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                schema: "ODA",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    baseType = table.Column<string>(name: "@baseType", type: "nvarchar(max)", nullable: true),
                    type = table.Column<string>(name: "@type", type: "nvarchar(max)", nullable: true),
                    schemaLocation = table.Column<string>(name: "@schemaLocation", type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartyInteractionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    InteractionItemId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notes_InteractionItems_InteractionItemId",
                        column: x => x.InteractionItemId,
                        principalSchema: "ODA",
                        principalTable: "InteractionItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Notes_PartyInteractions_PartyInteractionId",
                        column: x => x.PartyInteractionId,
                        principalSchema: "ODA",
                        principalTable: "PartyInteractions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RelatedParties",
                schema: "ODA",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    baseType = table.Column<string>(name: "@baseType", type: "nvarchar(max)", nullable: true),
                    type = table.Column<string>(name: "@type", type: "nvarchar(max)", nullable: true),
                    schemaLocation = table.Column<string>(name: "@schemaLocation", type: "nvarchar(max)", nullable: true),
                    referredType = table.Column<string>(name: "@referredType", type: "nvarchar(max)", nullable: true),
                    Href = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartyInteractionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InteractionItemId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelatedParties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RelatedParties_InteractionItems_InteractionItemId",
                        column: x => x.InteractionItemId,
                        principalSchema: "ODA",
                        principalTable: "InteractionItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RelatedParties_PartyInteractions_PartyInteractionId",
                        column: x => x.PartyInteractionId,
                        principalSchema: "ODA",
                        principalTable: "PartyInteractions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_InteractionItemId",
                schema: "ODA",
                table: "Attachments",
                column: "InteractionItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_PartyInteractionId",
                schema: "ODA",
                table: "Attachments",
                column: "PartyInteractionId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalIdentifiers_PartyInteractionId",
                schema: "ODA",
                table: "ExternalIdentifiers",
                column: "PartyInteractionId");

            migrationBuilder.CreateIndex(
                name: "IX_InteractionItems_PartyInteractionId",
                schema: "ODA",
                table: "InteractionItems",
                column: "PartyInteractionId");

            migrationBuilder.CreateIndex(
                name: "IX_InteractionRelationships_PartyInteractionId",
                schema: "ODA",
                table: "InteractionRelationships",
                column: "PartyInteractionId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_InteractionItemId",
                schema: "ODA",
                table: "Notes",
                column: "InteractionItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_PartyInteractionId",
                schema: "ODA",
                table: "Notes",
                column: "PartyInteractionId");

            migrationBuilder.CreateIndex(
                name: "IX_RelatedChannels_PartyInteractionId",
                schema: "ODA",
                table: "RelatedChannels",
                column: "PartyInteractionId");

            migrationBuilder.CreateIndex(
                name: "IX_RelatedParties_InteractionItemId",
                schema: "ODA",
                table: "RelatedParties",
                column: "InteractionItemId");

            migrationBuilder.CreateIndex(
                name: "IX_RelatedParties_PartyInteractionId",
                schema: "ODA",
                table: "RelatedParties",
                column: "PartyInteractionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attachments",
                schema: "ODA");

            migrationBuilder.DropTable(
                name: "ExternalIdentifiers",
                schema: "ODA");

            migrationBuilder.DropTable(
                name: "InteractionRelationships",
                schema: "ODA");

            migrationBuilder.DropTable(
                name: "Notes",
                schema: "ODA");

            migrationBuilder.DropTable(
                name: "RelatedChannels",
                schema: "ODA");

            migrationBuilder.DropTable(
                name: "RelatedParties",
                schema: "ODA");

            migrationBuilder.DropTable(
                name: "InteractionItems",
                schema: "ODA");

            migrationBuilder.DropTable(
                name: "PartyInteractions",
                schema: "ODA");
        }
    }
}
