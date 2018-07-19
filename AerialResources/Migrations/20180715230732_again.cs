using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AerialResources.Migrations
{
    public partial class again : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentID",
                table: "Student");

            migrationBuilder.AddColumn<int>(
                name: "StudentID",
                table: "Parent",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentID",
                table: "Parent");

            migrationBuilder.AddColumn<int>(
                name: "ParentID",
                table: "Student",
                nullable: false,
                defaultValue: 0);
        }
    }
}
