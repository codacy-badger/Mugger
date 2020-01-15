using Microsoft.EntityFrameworkCore.Migrations;

namespace Mugger.Infrastructure.Migrations
{
    public partial class lowercase_url : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icon",
                table: "Webshops");

            migrationBuilder.DropColumn(
                name: "Icon",
                table: "Tags");

            migrationBuilder.RenameColumn(
                name: "ImageURL",
                table: "Webshops",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "ImageURL",
                table: "Seller",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "ImageURL",
                table: "Brand",
                newName: "ImageUrl");

            migrationBuilder.AddColumn<string>(
                name: "IconUrl",
                table: "Webshops",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IconUrl",
                table: "Webshops");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Webshops",
                newName: "ImageURL");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Seller",
                newName: "ImageURL");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Brand",
                newName: "ImageURL");

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "Webshops",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "Tags",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
