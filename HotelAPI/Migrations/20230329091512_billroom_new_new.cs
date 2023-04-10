using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelAPI.Migrations
{
    /// <inheritdoc />
    public partial class billroom_new_new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Billsroom_Customers_cunstomerCustomerId",
                table: "Billsroom");

            migrationBuilder.RenameColumn(
                name: "cunstomerCustomerId",
                table: "Billsroom",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Billsroom_cunstomerCustomerId",
                table: "Billsroom",
                newName: "IX_Billsroom_CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Billsroom_Customers_CustomerId",
                table: "Billsroom",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Billsroom_Customers_CustomerId",
                table: "Billsroom");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Billsroom",
                newName: "cunstomerCustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Billsroom_CustomerId",
                table: "Billsroom",
                newName: "IX_Billsroom_cunstomerCustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Billsroom_Customers_cunstomerCustomerId",
                table: "Billsroom",
                column: "cunstomerCustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
