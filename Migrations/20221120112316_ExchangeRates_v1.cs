using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExchangeRatesApp.Migrations
{
    /// <inheritdoc />
    public partial class ExchangeRatesv1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Selector = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reverse = table.Column<bool>(type: "bit", nullable: false),
                    Timeout = table.Column<int>(type: "int", nullable: false),
                    By = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Name);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Banks");
        }
    }
}
