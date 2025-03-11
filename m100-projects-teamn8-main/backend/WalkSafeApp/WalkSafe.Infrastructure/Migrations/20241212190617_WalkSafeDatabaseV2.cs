using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WalkSafe.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class WalkSafeDatabaseV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GreenSpace_PointOfInterest_Id",
                table: "GreenSpace");

            migrationBuilder.DropForeignKey(
                name: "FK_Landmark_PointOfInterest_Id",
                table: "Landmark");

            migrationBuilder.DropTable(
                name: "PointOfInterest");

            migrationBuilder.DropColumn(
                name: "Area",
                table: "GreenSpace");

            migrationBuilder.AddColumn<float>(
                name: "Latitude",
                table: "Landmark",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Longitude",
                table: "Landmark",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Landmark",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "Latitude",
                table: "GreenSpace",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Longitude",
                table: "GreenSpace",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "GreenSpace",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Landmark");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Landmark");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Landmark");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "GreenSpace");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "GreenSpace");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "GreenSpace");

            migrationBuilder.AddColumn<double>(
                name: "Area",
                table: "GreenSpace",
                type: "float",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PointOfInterest",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointOfInterest", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_GreenSpace_PointOfInterest_Id",
                table: "GreenSpace",
                column: "Id",
                principalTable: "PointOfInterest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Landmark_PointOfInterest_Id",
                table: "Landmark",
                column: "Id",
                principalTable: "PointOfInterest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
