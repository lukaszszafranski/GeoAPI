using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StockAPI.Migrations
{
    public partial class CreateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quote",
                columns: table => new
                {
                    Symbol = table.Column<string>(nullable: false),
                    CompanyName = table.Column<string>(nullable: true),
                    PrimaryExchange = table.Column<string>(nullable: true),
                    CalculationPrice = table.Column<string>(nullable: true),
                    Open = table.Column<double>(nullable: true),
                    OpenTime = table.Column<long>(nullable: true),
                    Close = table.Column<double>(nullable: true),
                    CloseTime = table.Column<long>(nullable: true),
                    High = table.Column<double>(nullable: true),
                    Low = table.Column<long>(nullable: true),
                    LatestPrice = table.Column<double>(nullable: true),
                    LatestSource = table.Column<string>(nullable: true),
                    LatestTime = table.Column<string>(nullable: true),
                    LatestUpdate = table.Column<long>(nullable: true),
                    LatestVolume = table.Column<long>(nullable: true),
                    DelayedPrice = table.Column<double>(nullable: true),
                    DelayedPriceTime = table.Column<long>(nullable: true),
                    ExtendedPrice = table.Column<double>(nullable: true),
                    ExtendedChange = table.Column<double>(nullable: true),
                    ExtendedChangePercent = table.Column<double>(nullable: true),
                    ExtendedPriceTime = table.Column<long>(nullable: true),
                    PreviousClose = table.Column<double>(nullable: true),
                    PreviousVolume = table.Column<long>(nullable: true),
                    Change = table.Column<double>(nullable: true),
                    ChangePercent = table.Column<double>(nullable: true),
                    Volume = table.Column<long>(nullable: true),
                    AvgTotalVolume = table.Column<long>(nullable: true),
                    MarketCap = table.Column<long>(nullable: true),
                    PeRatio = table.Column<double>(nullable: true),
                    Week52High = table.Column<double>(nullable: true),
                    Week52Low = table.Column<double>(nullable: true),
                    YtdChange = table.Column<double>(nullable: true),
                    LastTradeTime = table.Column<long>(nullable: true),
                    IsUsMarketOpen = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quote", x => x.Symbol);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StockData",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QuoteSymbol = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockData", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StockData_Quote_QuoteSymbol",
                        column: x => x.QuoteSymbol,
                        principalTable: "Quote",
                        principalColumn: "Symbol",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Chart",
                columns: table => new
                {
                    Date = table.Column<DateTimeOffset>(nullable: false),
                    Open = table.Column<double>(nullable: true),
                    Close = table.Column<double>(nullable: true),
                    High = table.Column<double>(nullable: true),
                    Low = table.Column<double>(nullable: true),
                    Volume = table.Column<long>(nullable: true),
                    UOpen = table.Column<double>(nullable: true),
                    UClose = table.Column<double>(nullable: true),
                    UHigh = table.Column<double>(nullable: true),
                    ULow = table.Column<double>(nullable: true),
                    UVolume = table.Column<long>(nullable: true),
                    Change = table.Column<double>(nullable: true),
                    ChangePercent = table.Column<double>(nullable: true),
                    Label = table.Column<string>(nullable: true),
                    ChangeOverTime = table.Column<double>(nullable: true),
                    StockDataID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chart", x => x.Date);
                    table.ForeignKey(
                        name: "FK_Chart_StockData_StockDataID",
                        column: x => x.StockDataID,
                        principalTable: "StockData",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chart_StockDataID",
                table: "Chart",
                column: "StockDataID");

            migrationBuilder.CreateIndex(
                name: "IX_StockData_QuoteSymbol",
                table: "StockData",
                column: "QuoteSymbol");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chart");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "StockData");

            migrationBuilder.DropTable(
                name: "Quote");
        }
    }
}
