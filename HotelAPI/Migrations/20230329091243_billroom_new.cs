using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelAPI.Migrations
{
    /// <inheritdoc />
    public partial class billroom_new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Billsroom_Bills_BillId",
                table: "Billsroom");

            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.RenameColumn(
                name: "BillId",
                table: "Billsroom",
                newName: "cunstomerCustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Billsroom_BillId",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Billsroom_Customers_cunstomerCustomerId",
                table: "Billsroom");

            migrationBuilder.RenameColumn(
                name: "cunstomerCustomerId",
                table: "Billsroom",
                newName: "BillId");

            migrationBuilder.RenameIndex(
                name: "IX_Billsroom_cunstomerCustomerId",
                table: "Billsroom",
                newName: "IX_Billsroom_BillId");

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    BillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.BillId);
                    table.ForeignKey(
                        name: "FK_Bills_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_CustomerId",
                table: "Bills",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Billsroom_Bills_BillId",
                table: "Billsroom",
                column: "BillId",
                principalTable: "Bills",
                principalColumn: "BillId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
