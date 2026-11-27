using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AFO.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class MovePricingIntoServiceContent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pricings");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ServiceContents",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<List<string>>(
                name: "Includes",
                table: "ServiceContents",
                type: "text[]",
                nullable: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "ServiceContents",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "ServiceContents");

            migrationBuilder.DropColumn(
                name: "Includes",
                table: "ServiceContents");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "ServiceContents");

            migrationBuilder.CreateTable(
                name: "Pricings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ServiceContentId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Includes = table.Column<List<string>>(type: "text[]", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pricings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pricings_ServiceContents_ServiceContentId",
                        column: x => x.ServiceContentId,
                        principalTable: "ServiceContents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pricings_ServiceContentId",
                table: "Pricings",
                column: "ServiceContentId");
        }
    }
}
