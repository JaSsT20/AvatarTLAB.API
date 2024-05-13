using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvatarTLAB.Backend.Migrations
{
    /// <inheritdoc />
    public partial class new_CharacterFightingStyles_TB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FightingStyles_Characters_CharacterId",
                table: "FightingStyles");

            migrationBuilder.DropIndex(
                name: "IX_FightingStyles_CharacterId",
                table: "FightingStyles");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "FightingStyles");

            migrationBuilder.CreateTable(
                name: "CharacterFightingStyle",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    FightingStyleId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterFightingStyle", x => new { x.CharacterId, x.FightingStyleId });
                    table.ForeignKey(
                        name: "FK_CharacterFightingStyle_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CharacterFightingStyle_FightingStyles_FightingStyleId",
                        column: x => x.FightingStyleId,
                        principalTable: "FightingStyles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterFightingStyle_FightingStyleId",
                table: "CharacterFightingStyle",
                column: "FightingStyleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterFightingStyle");

            migrationBuilder.AddColumn<int>(
                name: "CharacterId",
                table: "FightingStyles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FightingStyles_CharacterId",
                table: "FightingStyles",
                column: "CharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_FightingStyles_Characters_CharacterId",
                table: "FightingStyles",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id");
        }
    }
}
