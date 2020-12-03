using Microsoft.EntityFrameworkCore.Migrations;

namespace gustav_v2.Migrations
{
    public partial class addOwner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerName",
                table: "Advert",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "OwnerPhone",
                table: "Advert",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerName",
                table: "Advert");

            migrationBuilder.DropColumn(
                name: "OwnerPhone",
                table: "Advert");
        }
    }
}
