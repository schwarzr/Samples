using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalAzure.RestContract.SqlServer.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ToDoEntries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Completed = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoEntries", x => x.Id);
                });

            migrationBuilder.InsertData("ToDoEntries", new[] { "Id", "Title", "DueDate" }, new object[] { Guid.NewGuid(), "Eat", new DateTime(2022, 5, 6, 13, 0, 0) });
            migrationBuilder.InsertData("ToDoEntries", new[] { "Id", "Title", "DueDate" }, new object[] { Guid.NewGuid(), "Sleep", new DateTime(2022, 5, 6, 8, 0, 0) });
            migrationBuilder.InsertData("ToDoEntries", new[] { "Id", "Title", "DueDate" }, new object[] { Guid.NewGuid(), "Code", new DateTime(2022, 5, 6, 11, 0, 0) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDoEntries");
        }
    }
}
