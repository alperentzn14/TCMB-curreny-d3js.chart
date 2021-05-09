using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Provision.Migrations
{
    public partial class provisionpay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    RecordId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InsertDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CurrencyCode = table.Column<string>(type: "text", nullable: true),
                    Unit = table.Column<int>(type: "integer", nullable: false),
                    ForexBuyingAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    ForexSellingAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    EffectiveBuyingAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    EffectiveSellingAmount = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.RecordId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Currencies");
        }
    }
}
