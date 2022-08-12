using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MRT.CardManagement.Persistence.Migrations
{
    public partial class initialCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CardType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InitialLoad = table.Column<int>(type: "int", nullable: false),
                    Validity = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Card",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Activated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LoadBalance = table.Column<int>(type: "int", nullable: false),
                    DiscountId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiscountIdType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardTypeId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Card_CardType_CardTypeId",
                        column: x => x.CardTypeId,
                        principalTable: "CardType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardId = table.Column<int>(type: "int", nullable: true),
                    DateOfTransaction = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionHistory_Card_CardId",
                        column: x => x.CardId,
                        principalTable: "Card",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "CardType",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "Description", "InitialLoad", "LastModifiedBy", "LastModifiedDate", "Name", "Validity" },
                values: new object[] { 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Regular Card", 100, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Q-Less Transport Card", 5 });

            migrationBuilder.InsertData(
                table: "CardType",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "Description", "InitialLoad", "LastModifiedBy", "LastModifiedDate", "Name", "Validity" },
                values: new object[] { 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Discount Card", 500, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Q-Less Discount Transport Card", 3 });

            migrationBuilder.InsertData(
                table: "Card",
                columns: new[] { "Id", "AccountNumber", "Activated", "CardTypeId", "CreatedBy", "DateCreated", "DiscountId", "DiscountIdType", "ExpirationDate", "LastModifiedBy", "LastModifiedDate", "LoadBalance" },
                values: new object[,]
                {
                    { 1, "5555-1111-1111", new DateTime(2022, 8, 11, 0, 0, 0, 0, DateTimeKind.Local), 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2027, 8, 11, 0, 0, 0, 0, DateTimeKind.Local), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100 },
                    { 2, "5555-2222-2222", new DateTime(2022, 8, 11, 0, 0, 0, 0, DateTimeKind.Local), 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2027, 8, 11, 0, 0, 0, 0, DateTimeKind.Local), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100 },
                    { 3, "5555-3333-3333", new DateTime(2022, 8, 11, 0, 0, 0, 0, DateTimeKind.Local), 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2027, 8, 11, 0, 0, 0, 0, DateTimeKind.Local), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100 },
                    { 4, "5555-4444-4444", new DateTime(2022, 8, 11, 0, 0, 0, 0, DateTimeKind.Local), 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2027, 8, 11, 0, 0, 0, 0, DateTimeKind.Local), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100 },
                    { 5, "5555-5555-5555", new DateTime(2022, 8, 11, 0, 0, 0, 0, DateTimeKind.Local), 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "11-1111-1111", "Senior Citizen ID", new DateTime(2025, 8, 11, 0, 0, 0, 0, DateTimeKind.Local), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100 },
                    { 6, "5555-6666-6666", new DateTime(2022, 8, 11, 0, 0, 0, 0, DateTimeKind.Local), 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2222-2222-2222", "Pwd ID", new DateTime(2025, 8, 11, 0, 0, 0, 0, DateTimeKind.Local), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100 },
                    { 7, "5555-7777-7777", new DateTime(2022, 8, 11, 0, 0, 0, 0, DateTimeKind.Local), 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "33-3333-3333", "Senior Citizen ID", new DateTime(2025, 8, 11, 0, 0, 0, 0, DateTimeKind.Local), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100 },
                    { 8, "5555-8888-8888", new DateTime(2022, 8, 11, 0, 0, 0, 0, DateTimeKind.Local), 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "4444-4444-4444", "Pwd ID", new DateTime(2025, 8, 11, 0, 0, 0, 0, DateTimeKind.Local), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Card_CardTypeId",
                table: "Card",
                column: "CardTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionHistory_CardId",
                table: "TransactionHistory",
                column: "CardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransactionHistory");

            migrationBuilder.DropTable(
                name: "Card");

            migrationBuilder.DropTable(
                name: "CardType");
        }
    }
}
