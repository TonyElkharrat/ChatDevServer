using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatDev.Migrations
{
    public partial class creationofchatsubjectandMessageTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26068a5e-725f-4889-b49c-340b585444f0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6410b787-3a5b-4294-81df-40796b6cb03b");

            migrationBuilder.AddColumn<string>(
                name: "ProfilPhoto",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SentDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SentBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChatSubjectId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7961e6ce-d994-4a4d-bcdf-4c3beb898cf1", "32ccb9fe-a4ef-44db-a139-49a03a4020cc", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dd36b253-88c3-40b3-be0f-92f4a9581011", "c82d3fac-243f-4989-ba71-2af31d50f9be", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7961e6ce-d994-4a4d-bcdf-4c3beb898cf1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd36b253-88c3-40b3-be0f-92f4a9581011");

            migrationBuilder.DropColumn(
                name: "ProfilPhoto",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "26068a5e-725f-4889-b49c-340b585444f0", "ff2f876a-894c-4f32-8a60-9889be35b70d", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6410b787-3a5b-4294-81df-40796b6cb03b", "5b225636-5200-4773-8fbf-b3a45bcecbdb", "Administrator", "ADMINISTRATOR" });
        }
    }
}
