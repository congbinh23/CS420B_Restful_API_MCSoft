using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CS420B_RestfulApi.Migrations
{
    /// <inheritdoc />
    public partial class CreateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientName",
                table: "HotelBooking");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Room",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "HotelBooking",
                newName: "BookingID");

            migrationBuilder.AlterColumn<int>(
                name: "status",
                table: "Room",
                type: "int",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<int>(
                name: "RoomNumber",
                table: "HotelBooking",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckinTime",
                table: "HotelBooking",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckoutTime",
                table: "HotelBooking",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "GuestID",
                table: "HotelBooking",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "HotelBooking",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Guest",
                columns: table => new
                {
                    GuestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guest", x => x.GuestID);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    PaymentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentMethod = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.PaymentID);
                    table.ForeignKey(
                        name: "FK_Payment_HotelBooking_BookingID",
                        column: x => x.BookingID,
                        principalTable: "HotelBooking",
                        principalColumn: "BookingID");
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    StaffID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelID = table.Column<int>(type: "int", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.StaffID);
                    table.ForeignKey(
                        name: "FK_Staff_Hotel_HotelID",
                        column: x => x.HotelID,
                        principalTable: "Hotel",
                        principalColumn: "HotelID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotelBooking_GuestID",
                table: "HotelBooking",
                column: "GuestID");

            migrationBuilder.CreateIndex(
                name: "IX_HotelBooking_RoomNumber",
                table: "HotelBooking",
                column: "RoomNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_BookingID",
                table: "Payment",
                column: "BookingID");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_HotelID",
                table: "Staff",
                column: "HotelID");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelBooking_Guest_GuestID",
                table: "HotelBooking",
                column: "GuestID",
                principalTable: "Guest",
                principalColumn: "GuestID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelBooking_Room_RoomNumber",
                table: "HotelBooking",
                column: "RoomNumber",
                principalTable: "Room",
                principalColumn: "RoomNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelBooking_Guest_GuestID",
                table: "HotelBooking");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelBooking_Room_RoomNumber",
                table: "HotelBooking");

            migrationBuilder.DropTable(
                name: "Guest");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropIndex(
                name: "IX_HotelBooking_GuestID",
                table: "HotelBooking");

            migrationBuilder.DropIndex(
                name: "IX_HotelBooking_RoomNumber",
                table: "HotelBooking");

            migrationBuilder.DropColumn(
                name: "CheckinTime",
                table: "HotelBooking");

            migrationBuilder.DropColumn(
                name: "CheckoutTime",
                table: "HotelBooking");

            migrationBuilder.DropColumn(
                name: "GuestID",
                table: "HotelBooking");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "HotelBooking");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Room",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "BookingID",
                table: "HotelBooking",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Room",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<int>(
                name: "RoomNumber",
                table: "HotelBooking",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClientName",
                table: "HotelBooking",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
