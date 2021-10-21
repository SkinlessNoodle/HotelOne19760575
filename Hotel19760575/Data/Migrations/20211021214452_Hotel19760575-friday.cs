using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel19760575.Data.Migrations
{
    public partial class Hotel19760575friday : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ManualBookingAdmin",
                columns: table => new
                {
                    BookingID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoomID = table.Column<int>(nullable: false),
                    CustomerEmail = table.Column<string>(nullable: false),
                    CheckIn = table.Column<DateTime>(nullable: false),
                    CheckOut = table.Column<DateTime>(nullable: false),
                    Cost = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManualBookingAdmin", x => x.BookingID);
                    table.ForeignKey(
                        name: "FK_ManualBookingAdmin_Customer_CustomerEmail",
                        column: x => x.CustomerEmail,
                        principalTable: "Customer",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManualBookingAdmin_Room_RoomID",
                        column: x => x.RoomID,
                        principalTable: "Room",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ManualBookingAdmin_CustomerEmail",
                table: "ManualBookingAdmin",
                column: "CustomerEmail");

            migrationBuilder.CreateIndex(
                name: "IX_ManualBookingAdmin_RoomID",
                table: "ManualBookingAdmin",
                column: "RoomID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ManualBookingAdmin");
        }
    }
}
