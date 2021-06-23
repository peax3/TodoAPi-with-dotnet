using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Main.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Todos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Activity = table.Column<string>(type: "TEXT", nullable: false),
                    IsCompleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "Activity", "IsCompleted" },
                values: new object[] { new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), "Walk the dog", false });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "Activity", "IsCompleted" },
                values: new object[] { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Walk the dog", false });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "Activity", "IsCompleted" },
                values: new object[] { new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "Walk the dog", false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Todos");
        }
    }
}
