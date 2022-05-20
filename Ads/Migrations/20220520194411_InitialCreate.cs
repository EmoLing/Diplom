using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ads.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdCoordinates",
                columns: table => new
                {
                    AdGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdCoordinates", x => x.AdGuid);
                });

            migrationBuilder.CreateTable(
                name: "Ads",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeAd = table.Column<int>(type: "int", nullable: false),
                    CoordinatesAdGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusAd = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ads", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Ads_AdCoordinates_CoordinatesAdGuid",
                        column: x => x.CoordinatesAdGuid,
                        principalTable: "AdCoordinates",
                        principalColumn: "AdGuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Image_Ads_AdGuid",
                        column: x => x.AdGuid,
                        principalTable: "Ads",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ads_CoordinatesAdGuid",
                table: "Ads",
                column: "CoordinatesAdGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Image_AdGuid",
                table: "Image",
                column: "AdGuid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Ads");

            migrationBuilder.DropTable(
                name: "AdCoordinates");
        }
    }
}
