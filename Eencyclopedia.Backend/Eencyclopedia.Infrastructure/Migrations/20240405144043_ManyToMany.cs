using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Eencyclopedia.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookUser_AspNetUsers_UsersId",
                table: "BookUser");

            migrationBuilder.DropForeignKey(
                name: "FK_BookUser_Books_FavoriteBooksId",
                table: "BookUser");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6eb7d598-b555-4566-9332-ba145453c276"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f9c31cd0-42a6-432b-8409-677dc7da975c"));

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "BookUser",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "FavoriteBooksId",
                table: "BookUser",
                newName: "BookId");

            migrationBuilder.RenameIndex(
                name: "IX_BookUser_UsersId",
                table: "BookUser",
                newName: "IX_BookUser_UserId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("97fead13-f782-4bb1-816d-35263a75c620"), null, "Admin", "ADMIN" },
                    { new Guid("f21046bf-85f0-4529-9a96-6cc41ea18469"), null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_BookUser_AspNetUsers_UserId",
                table: "BookUser",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookUser_Books_BookId",
                table: "BookUser",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookUser_AspNetUsers_UserId",
                table: "BookUser");

            migrationBuilder.DropForeignKey(
                name: "FK_BookUser_Books_BookId",
                table: "BookUser");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("97fead13-f782-4bb1-816d-35263a75c620"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f21046bf-85f0-4529-9a96-6cc41ea18469"));

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "BookUser",
                newName: "UsersId");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "BookUser",
                newName: "FavoriteBooksId");

            migrationBuilder.RenameIndex(
                name: "IX_BookUser_UserId",
                table: "BookUser",
                newName: "IX_BookUser_UsersId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("6eb7d598-b555-4566-9332-ba145453c276"), null, "Admin", "ADMIN" },
                    { new Guid("f9c31cd0-42a6-432b-8409-677dc7da975c"), null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_BookUser_AspNetUsers_UsersId",
                table: "BookUser",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookUser_Books_FavoriteBooksId",
                table: "BookUser",
                column: "FavoriteBooksId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
