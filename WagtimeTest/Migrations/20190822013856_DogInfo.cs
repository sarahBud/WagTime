using Microsoft.EntityFrameworkCore.Migrations;

namespace WagtimeTest.Migrations
{
    public partial class DogInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DogBreed",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DogName",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DogBreed",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DogName",
                table: "AspNetUsers");
        }
    }
}
