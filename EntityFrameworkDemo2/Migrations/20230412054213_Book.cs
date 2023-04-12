using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkDemo2.Migrations
{
    /// <inheritdoc />
    public partial class Book : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAddress_Users_UserId",
                table: "UserAddress");

            migrationBuilder.DropIndex(
                name: "IX_UserAddress_UserId",
                table: "UserAddress");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "UserAddress",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1000, 10"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAddress_UserId",
                table: "UserAddress",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddress_Users_UserId",
                table: "UserAddress",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAddress_Users_UserId",
                table: "UserAddress");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropIndex(
                name: "IX_UserAddress_UserId",
                table: "UserAddress");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "UserAddress",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAddress_UserId",
                table: "UserAddress",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddress_Users_UserId",
                table: "UserAddress",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
