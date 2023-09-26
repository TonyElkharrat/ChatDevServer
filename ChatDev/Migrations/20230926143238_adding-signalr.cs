using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatDev.Migrations
{
    public partial class addingsignalr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c82630c-6bde-468a-9984-9dc651e839e7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51394d25-5ca4-41c5-a0e5-ebca2f2c8bad");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a8966167-5ea0-4d0a-984e-952fcf7e058e", "879a85bd-c567-4a3f-aa44-0152935d06bd", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c1825ab9-3753-41c1-b5cf-219b121640f2", "f66e3615-e278-4c2b-a056-0d73d2d727a6", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8966167-5ea0-4d0a-984e-952fcf7e058e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1825ab9-3753-41c1-b5cf-219b121640f2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2c82630c-6bde-468a-9984-9dc651e839e7", "e63839f2-5521-41e1-8e95-3edefc9dfbce", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "51394d25-5ca4-41c5-a0e5-ebca2f2c8bad", "f487f22b-646c-4d53-a325-5b7b8f66a8c5", "User", "USER" });
        }
    }
}
