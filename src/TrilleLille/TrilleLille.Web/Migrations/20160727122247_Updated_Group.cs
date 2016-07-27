using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;
using TrilleLille.Web.Models;

namespace TrilleLille.Web.Migrations
{
    public partial class Updated_Group : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgeGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Range = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgeGroup", x => x.Id);
                });

            migrationBuilder.AddColumn<int>(
                name: "AgeGroupId",
                table: "Groups",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "GroupIntro",
                table: "Groups",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SeekingGender",
                table: "Groups",
                nullable: false,
                defaultValue: Gender.Male);

            migrationBuilder.AddColumn<string>(
                name: "ProfileImageUrl",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_AgeGroupId",
                table: "Groups",
                column: "AgeGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_AgeGroup_AgeGroupId",
                table: "Groups",
                column: "AgeGroupId",
                principalTable: "AgeGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_AgeGroup_AgeGroupId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_AgeGroupId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "AgeGroupId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "GroupIntro",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "SeekingGender",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "ProfileImageUrl",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "AgeGroup");
        }
    }
}
