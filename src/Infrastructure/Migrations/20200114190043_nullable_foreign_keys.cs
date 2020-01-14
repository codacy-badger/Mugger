using Microsoft.EntityFrameworkCore.Migrations;

namespace Mugger.Infrastructure.Migrations
{
    public partial class nullable_foreign_keys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seller_Webshops_WebshopId",
                table: "Seller");

            migrationBuilder.AlterColumn<long>(
                name: "WebshopId",
                table: "Seller",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "BrandId",
                table: "Products",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Seller_Webshops_WebshopId",
                table: "Seller",
                column: "WebshopId",
                principalTable: "Webshops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seller_Webshops_WebshopId",
                table: "Seller");

            migrationBuilder.AlterColumn<long>(
                name: "WebshopId",
                table: "Seller",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "BrandId",
                table: "Products",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Seller_Webshops_WebshopId",
                table: "Seller",
                column: "WebshopId",
                principalTable: "Webshops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
