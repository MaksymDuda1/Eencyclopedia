using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Eencyclopedia.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class QWE : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4a0695bd-5547-4399-ba29-e163433d06a6"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b74baa8a-6baf-422a-aa00-a673a1e4b914"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("2e5ef116-734c-42e8-998d-da1827e6174a"), null, "User", "USER" },
                    { new Guid("d61f153b-520e-4a2f-bf10-f6ed23c9c7f5"), null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2e5ef116-734c-42e8-998d-da1827e6174a"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d61f153b-520e-4a2f-bf10-f6ed23c9c7f5"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("4a0695bd-5547-4399-ba29-e163433d06a6"), null, "User", "USER" },
                    { new Guid("b74baa8a-6baf-422a-aa00-a673a1e4b914"), null, "Admin", "ADMIN" }
                });
        }
    }
}
