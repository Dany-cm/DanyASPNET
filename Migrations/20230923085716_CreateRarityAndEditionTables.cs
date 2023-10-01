using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DanyTCG.Migrations
{
    /// <inheritdoc />
    public partial class CreateRarityAndEditionTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Edition",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "Rarity",
                table: "Inventories");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Inventories",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EditionId",
                table: "Inventories",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RarityId",
                table: "Inventories",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Editions",
                columns: table => new
                {
                    EditionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editions", x => x.EditionId);
                });

            migrationBuilder.CreateTable(
                name: "Rarities",
                columns: table => new
                {
                    RarityId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rarities", x => x.RarityId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_EditionId",
                table: "Inventories",
                column: "EditionId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_RarityId",
                table: "Inventories",
                column: "RarityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Editions_EditionId",
                table: "Inventories",
                column: "EditionId",
                principalTable: "Editions",
                principalColumn: "EditionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Rarities_RarityId",
                table: "Inventories",
                column: "RarityId",
                principalTable: "Rarities",
                principalColumn: "RarityId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Editions_EditionId",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Rarities_RarityId",
                table: "Inventories");

            migrationBuilder.DropTable(
                name: "Editions");

            migrationBuilder.DropTable(
                name: "Rarities");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_EditionId",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_RarityId",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "EditionId",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "RarityId",
                table: "Inventories");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Inventories",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "Edition",
                table: "Inventories",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Rarity",
                table: "Inventories",
                type: "TEXT",
                nullable: true);
        }
    }
}
