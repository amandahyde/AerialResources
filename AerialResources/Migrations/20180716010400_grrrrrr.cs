using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AerialResources.Migrations
{
    public partial class grrrrrr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parent");

            migrationBuilder.AddColumn<string>(
                name: "ParentContact",
                table: "Student",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ParentName",
                table: "Student",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentContact",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "ParentName",
                table: "Student");

            migrationBuilder.CreateTable(
                name: "Parent",
                columns: table => new
                {
                    ParentID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    StudentID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parent", x => x.ParentID);
                });
        }
    }
}
