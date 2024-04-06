using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Eencyclopedia.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedImageToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("97fead13-f782-4bb1-816d-35263a75c620"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f21046bf-85f0-4529-9a96-6cc41ea18469"));

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "AspNetUsers",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("4a0695bd-5547-4399-ba29-e163433d06a6"), null, "User", "USER" },
                    { new Guid("b74baa8a-6baf-422a-aa00-a673a1e4b914"), null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4a0695bd-5547-4399-ba29-e163433d06a6"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b74baa8a-6baf-422a-aa00-a673a1e4b914"));

            migrationBuilder.DropColumn(
                name: "Image",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("97fead13-f782-4bb1-816d-35263a75c620"), null, "Admin", "ADMIN" },
                    { new Guid("f21046bf-85f0-4529-9a96-6cc41ea18469"), null, "User", "USER" }
                });
        }
    }
}
