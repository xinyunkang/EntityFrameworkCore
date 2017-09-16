using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SamuraiApp.Data.Migrations
{
    public partial class samurais : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quote_Samurai_SamuraiId",
                table: "Quote");

            migrationBuilder.DropForeignKey(
                name: "FK_SamuraiBattle_Samurai_SamuraiId",
                table: "SamuraiBattle");

            migrationBuilder.DropForeignKey(
                name: "FK_SecretIdentity_Samurai_SamuraiId",
                table: "SecretIdentity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Samurai",
                table: "Samurai");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Quote",
                table: "Quote");

            migrationBuilder.RenameTable(
                name: "Samurai",
                newName: "Samurais");

            migrationBuilder.RenameTable(
                name: "Quote",
                newName: "Quotes");

            migrationBuilder.RenameIndex(
                name: "IX_Quote_SamuraiId",
                table: "Quotes",
                newName: "IX_Quotes_SamuraiId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Samurais",
                table: "Samurais",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Quotes",
                table: "Quotes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Quotes_Samurais_SamuraiId",
                table: "Quotes",
                column: "SamuraiId",
                principalTable: "Samurais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SamuraiBattle_Samurais_SamuraiId",
                table: "SamuraiBattle",
                column: "SamuraiId",
                principalTable: "Samurais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SecretIdentity_Samurais_SamuraiId",
                table: "SecretIdentity",
                column: "SamuraiId",
                principalTable: "Samurais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quotes_Samurais_SamuraiId",
                table: "Quotes");

            migrationBuilder.DropForeignKey(
                name: "FK_SamuraiBattle_Samurais_SamuraiId",
                table: "SamuraiBattle");

            migrationBuilder.DropForeignKey(
                name: "FK_SecretIdentity_Samurais_SamuraiId",
                table: "SecretIdentity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Samurais",
                table: "Samurais");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Quotes",
                table: "Quotes");

            migrationBuilder.RenameTable(
                name: "Samurais",
                newName: "Samurai");

            migrationBuilder.RenameTable(
                name: "Quotes",
                newName: "Quote");

            migrationBuilder.RenameIndex(
                name: "IX_Quotes_SamuraiId",
                table: "Quote",
                newName: "IX_Quote_SamuraiId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Samurai",
                table: "Samurai",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Quote",
                table: "Quote",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Quote_Samurai_SamuraiId",
                table: "Quote",
                column: "SamuraiId",
                principalTable: "Samurai",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SamuraiBattle_Samurai_SamuraiId",
                table: "SamuraiBattle",
                column: "SamuraiId",
                principalTable: "Samurai",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SecretIdentity_Samurai_SamuraiId",
                table: "SecretIdentity",
                column: "SamuraiId",
                principalTable: "Samurai",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
