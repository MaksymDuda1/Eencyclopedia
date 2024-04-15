using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Eencyclopedia.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedIdToUsersBooksTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ce02397e-796a-4ff3-be59-e614bd426e15"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ce9f5ee2-e080-4763-b3ee-393bd939992a"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "BookUser",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("1c6dab3d-aa33-465b-b665-b94ad781c50d"), null, "Admin", "ADMIN" },
                    { new Guid("f570a275-ef72-4b0b-b7ad-08f20c70afea"), null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1c6dab3d-aa33-465b-b665-b94ad781c50d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f570a275-ef72-4b0b-b7ad-08f20c70afea"));

            migrationBuilder.DropColumn(
                name: "Id",
                table: "BookUser");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("ce02397e-796a-4ff3-be59-e614bd426e15"), null, "Admin", "ADMIN" },
                    { new Guid("ce9f5ee2-e080-4763-b3ee-393bd939992a"), null, "User", "USER" }
                });
        }
    }
}
