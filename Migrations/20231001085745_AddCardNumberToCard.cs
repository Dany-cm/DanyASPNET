using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DanyTCG.Migrations
{
    /// <inheritdoc />
    public partial class AddCardNumberToCard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CardNumber",
                table: "Cards",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardNumber",
                table: "Cards");
        }
    }
}
