using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelAPI.Migrations
{
    /// <inheritdoc />
    public partial class billroom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillRoom_Bills_BillId",
                table: "BillRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_BillRoom_Rooms_RoomId",
                table: "BillRoom");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BillRoom",
                table: "BillRoom");

            migrationBuilder.DropColumn(
                name: "vergünstigung",
                table: "BillRoom");

            migrationBuilder.RenameTable(
                name: "BillRoom",
                newName: "Billsroom");

            migrationBuilder.RenameIndex(
                name: "IX_BillRoom_RoomId",
                table: "Billsroom",
                newName: "IX_Billsroom_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_BillRoom_BillId",
                table: "Billsroom",
                newName: "IX_Billsroom_BillId");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Billsroom",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Billsroom",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Billsroom",
                table: "Billsroom",
                column: "BillRoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Billsroom_Bills_BillId",
                table: "Billsroom",
                column: "BillId",
                principalTable: "Bills",
                principalColumn: "BillId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Billsroom_Rooms_RoomId",
                table: "Billsroom",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Billsroom_Bills_BillId",
                table: "Billsroom");

            migrationBuilder.DropForeignKey(
                name: "FK_Billsroom_Rooms_RoomId",
                table: "Billsroom");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Billsroom",
                table: "Billsroom");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Billsroom");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Billsroom");

            migrationBuilder.RenameTable(
                name: "Billsroom",
                newName: "BillRoom");

            migrationBuilder.RenameIndex(
                name: "IX_Billsroom_RoomId",
                table: "BillRoom",
                newName: "IX_BillRoom_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Billsroom_BillId",
                table: "BillRoom",
                newName: "IX_BillRoom_BillId");

            migrationBuilder.AddColumn<decimal>(
                name: "vergünstigung",
                table: "BillRoom",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BillRoom",
                table: "BillRoom",
                column: "BillRoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_BillRoom_Bills_BillId",
                table: "BillRoom",
                column: "BillId",
                principalTable: "Bills",
                principalColumn: "BillId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BillRoom_Rooms_RoomId",
                table: "BillRoom",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
