using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelProject.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class identity_create6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Rezervations",
                newName: "customerId");

            migrationBuilder.AddColumn<int>(
                name: "CustomerIdd",
                table: "Rezervations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Rezervations_customerId",
                table: "Rezervations",
                column: "customerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervations_Customers_customerId",
                table: "Rezervations",
                column: "customerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervations_Customers_customerId",
                table: "Rezervations");

            migrationBuilder.DropIndex(
                name: "IX_Rezervations_customerId",
                table: "Rezervations");

            migrationBuilder.DropColumn(
                name: "CustomerIdd",
                table: "Rezervations");

            migrationBuilder.RenameColumn(
                name: "customerId",
                table: "Rezervations",
                newName: "CustomerId");
        }
    }
}
