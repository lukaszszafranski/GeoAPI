using Microsoft.EntityFrameworkCore.Migrations;

namespace GeolocationAPI.Migrations
{
    public partial class CreateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GeolocationData",
                columns: table => new
                {
                    IP = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    ContinentCode = table.Column<string>(nullable: true),
                    ContinentName = table.Column<string>(nullable: true),
                    CountryCode = table.Column<string>(nullable: true),
                    CountryName = table.Column<string>(nullable: true),
                    RegionCode = table.Column<string>(nullable: true),
                    RegionName = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeolocationData", x => x.IP);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeolocationData");
        }
    }
}
