using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Eencyclopedia.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("97507868-724d-4484-abe8-c9e44628061d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c1638020-7c4d-4b84-9b6f-4f4846c01f5b"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("ce02397e-796a-4ff3-be59-e614bd426e15"), null, "Admin", "ADMIN" },
                    { new Guid("ce9f5ee2-e080-4763-b3ee-393bd939992a"), null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ce02397e-796a-4ff3-be59-e614bd426e15"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ce9f5ee2-e080-4763-b3ee-393bd939992a"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("97507868-724d-4484-abe8-c9e44628061d"), null, "Admin", "ADMIN" },
                    { new Guid("c1638020-7c4d-4b84-9b6f-4f4846c01f5b"), null, "User", "USER" }
                });
        }
    }
}
