using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvatarTLAB.Backend.Migrations
{
    /// <inheritdoc />
    public partial class RPLC_BDate_Born : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterFightingStyle_Characters_CharacterId",
                table: "CharacterFightingStyle");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterFightingStyle_FightingStyles_FightingStyleId",
                table: "CharacterFightingStyle");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Episodes_FirstEpisodeId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Episodes_LastEpisodeId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Characters");

            migrationBuilder.AddColumn<string>(
                name: "Born",
                table: "Characters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterFightingStyle_Characters_CharacterId",
                table: "CharacterFightingStyle",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterFightingStyle_FightingStyles_FightingStyleId",
                table: "CharacterFightingStyle",
                column: "FightingStyleId",
                principalTable: "FightingStyles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Episodes_FirstEpisodeId",
                table: "Characters",
                column: "FirstEpisodeId",
                principalTable: "Episodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Episodes_LastEpisodeId",
                table: "Characters",
                column: "LastEpisodeId",
                principalTable: "Episodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterFightingStyle_Characters_CharacterId",
                table: "CharacterFightingStyle");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterFightingStyle_FightingStyles_FightingStyleId",
                table: "CharacterFightingStyle");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Episodes_FirstEpisodeId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Episodes_LastEpisodeId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Born",
                table: "Characters");

            migrationBuilder.AddColumn<DateOnly>(
                name: "BirthDate",
                table: "Characters",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterFightingStyle_Characters_CharacterId",
                table: "CharacterFightingStyle",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterFightingStyle_FightingStyles_FightingStyleId",
                table: "CharacterFightingStyle",
                column: "FightingStyleId",
                principalTable: "FightingStyles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Episodes_FirstEpisodeId",
                table: "Characters",
                column: "FirstEpisodeId",
                principalTable: "Episodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Episodes_LastEpisodeId",
                table: "Characters",
                column: "LastEpisodeId",
                principalTable: "Episodes",
                principalColumn: "Id");
        }
    }
}
