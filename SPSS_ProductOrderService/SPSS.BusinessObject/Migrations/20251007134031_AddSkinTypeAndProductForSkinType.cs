using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SPSS.BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class AddSkinTypeAndProductForSkinType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SkinTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkinTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductForSkinTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkinTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductForSkinTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductForSkinTypes_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductForSkinTypes_SkinTypes_SkinTypeId",
                        column: x => x.SkinTypeId,
                        principalTable: "SkinTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductForSkinTypes_ProductId",
                table: "ProductForSkinTypes",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductForSkinTypes_SkinTypeId",
                table: "ProductForSkinTypes",
                column: "SkinTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductForSkinTypes");

            migrationBuilder.DropTable(
                name: "SkinTypes");
        }
    }
}
