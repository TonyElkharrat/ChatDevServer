using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatDev.Migrations
{
    public partial class addforeignkeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "824c83e8-53d0-45cd-88f7-76f1b5076415");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "962da1f1-f770-424e-b6ff-6324a941316e");

            migrationBuilder.DropColumn(
                name: "SentBy",
                table: "Messages");

            migrationBuilder.AlterColumn<Guid>(
                name: "ChatSubjectId",
                table: "Messages",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Messages",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2c82630c-6bde-468a-9984-9dc651e839e7", "e63839f2-5521-41e1-8e95-3edefc9dfbce", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "51394d25-5ca4-41c5-a0e5-ebca2f2c8bad", "f487f22b-646c-4d53-a325-5b7b8f66a8c5", "User", "USER" });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ChatSubjectId",
                table: "Messages",
                column: "ChatSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserId",
                table: "Messages",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_UserId",
                table: "Messages",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_ChatSubjects_ChatSubjectId",
                table: "Messages",
                column: "ChatSubjectId",
                principalTable: "ChatSubjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_UserId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_ChatSubjects_ChatSubjectId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ChatSubjectId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_UserId",
                table: "Messages");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c82630c-6bde-468a-9984-9dc651e839e7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51394d25-5ca4-41c5-a0e5-ebca2f2c8bad");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Messages");

            migrationBuilder.AlterColumn<string>(
                name: "ChatSubjectId",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "SentBy",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "824c83e8-53d0-45cd-88f7-76f1b5076415", "2463fe93-e57b-44a8-8671-9a41b69cac4e", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "962da1f1-f770-424e-b6ff-6324a941316e", "6b3fe7d2-5ea0-4517-9285-91c5511e008e", "User", "USER" });
        }
    }
}
