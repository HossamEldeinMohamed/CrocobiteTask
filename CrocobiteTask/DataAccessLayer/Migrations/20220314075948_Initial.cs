using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrocobitTask.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Registrations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SendingCompanyID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReceivingCompanyID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registrations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Registrations_Companies_ReceivingCompanyID",
                        column: x => x.ReceivingCompanyID,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Registrations_Companies_SendingCompanyID",
                        column: x => x.SendingCompanyID,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("5fc147e5-5c7a-4ec9-aad9-cd5a7b27c3d7"), "Crocobite1" },
                    { new Guid("eaf5f253-b1fc-4a84-ad0f-c4ffebc5d9f3"), "Crocobite2" },
                    { new Guid("e91e5070-9cd4-4849-a159-cf69fafdcc2d"), "Crocobite3" },
                    { new Guid("6f9317a0-4f78-4245-8835-884bdba449b5"), "Crocobite4" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_ReceivingCompanyID",
                table: "Registrations",
                column: "ReceivingCompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_SendingCompanyID",
                table: "Registrations",
                column: "SendingCompanyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registrations");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
