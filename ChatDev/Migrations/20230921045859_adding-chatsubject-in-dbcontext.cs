using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatDev.Migrations
{
    public partial class addingchatsubjectindbcontext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7961e6ce-d994-4a4d-bcdf-4c3beb898cf1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd36b253-88c3-40b3-be0f-92f4a9581011");

            migrationBuilder.CreateTable(
                name: "ChatSubjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatSubjects", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "824c83e8-53d0-45cd-88f7-76f1b5076415", "2463fe93-e57b-44a8-8671-9a41b69cac4e", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "962da1f1-f770-424e-b6ff-6324a941316e", "6b3fe7d2-5ea0-4517-9285-91c5511e008e", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatSubjects");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "824c83e8-53d0-45cd-88f7-76f1b5076415");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "962da1f1-f770-424e-b6ff-6324a941316e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7961e6ce-d994-4a4d-bcdf-4c3beb898cf1", "32ccb9fe-a4ef-44db-a139-49a03a4020cc", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dd36b253-88c3-40b3-be0f-92f4a9581011", "c82d3fac-243f-4989-ba71-2af31d50f9be", "User", "USER" });
        }
    }
}
