using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_Databas___Robin_R.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfLoan",
                table: "Libraries");

            migrationBuilder.DropColumn(
                name: "DateOfReturn",
                table: "Libraries");

            migrationBuilder.DropColumn(
                name: "IsRented",
                table: "Libraries");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Libraries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DateOfLoan",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DateOfReturn",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsRented",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Libraries");

            migrationBuilder.DropColumn(
                name: "DateOfLoan",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "DateOfReturn",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "IsRented",
                table: "Books");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfLoan",
                table: "Libraries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfReturn",
                table: "Libraries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsRented",
                table: "Libraries",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
