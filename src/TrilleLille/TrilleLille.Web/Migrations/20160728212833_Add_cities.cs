using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;
using TrilleLille.Web.Models;

namespace TrilleLille.Web.Migrations
{
    public partial class Add_cities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_AgeGroups_AgeGroupId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_AgeGroupId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "AgeGroupId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "SeekingGender",
                table: "Groups");

            migrationBuilder.CreateTable(
                name: "CIties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CIties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CityId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Areas_CIties_CityId",
                        column: x => x.CityId,
                        principalTable: "CIties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddColumn<int>(
                name: "AreaId",
                table: "Locations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ChildId",
                table: "Groups",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Groups",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Groups",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "ZipCode",
                table: "Locations",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_AreaId",
                table: "Locations",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_ChildId",
                table: "Groups",
                column: "ChildId");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_CityId",
                table: "Areas",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Children_ChildId",
                table: "Groups",
                column: "ChildId",
                principalTable: "Children",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Areas_AreaId",
                table: "Locations",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Children_ChildId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Areas_AreaId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_AreaId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Groups_ChildId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "AreaId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "ChildId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Groups");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "CIties");

            migrationBuilder.AddColumn<int>(
                name: "AgeGroupId",
                table: "Groups",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SeekingGender",
                table: "Groups",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ZipCode",
                table: "Locations",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_AgeGroupId",
                table: "Groups",
                column: "AgeGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_AgeGroups_AgeGroupId",
                table: "Groups",
                column: "AgeGroupId",
                principalTable: "AgeGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
