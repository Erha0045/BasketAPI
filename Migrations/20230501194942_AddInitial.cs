using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Basket.API.Migrations
{
    /// <inheritdoc />
    public partial class AddInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BasketHeaders",
                columns: table => new
                {
                    BasketHeaderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketHeaders", x => x.BasketHeaderId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WineProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ProductGuid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Origin = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AlcoholPercentage = table.Column<float>(type: "float", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Size = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WineProducts", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BasketDetails",
                columns: table => new
                {
                    BasketDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BasketHeaderId = table.Column<int>(type: "int", nullable: false),
                    WineId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketDetails", x => x.BasketDetailsId);
                    table.ForeignKey(
                        name: "FK_BasketDetails_BasketHeaders_BasketHeaderId",
                        column: x => x.BasketHeaderId,
                        principalTable: "BasketHeaders",
                        principalColumn: "BasketHeaderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasketDetails_WineProducts_WineId",
                        column: x => x.WineId,
                        principalTable: "WineProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_BasketDetails_BasketHeaderId",
                table: "BasketDetails",
                column: "BasketHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketDetails_WineId",
                table: "BasketDetails",
                column: "WineId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketDetails");

            migrationBuilder.DropTable(
                name: "BasketHeaders");

            migrationBuilder.DropTable(
                name: "WineProducts");
        }
    }
}
