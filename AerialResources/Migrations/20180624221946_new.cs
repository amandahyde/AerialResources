using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AerialResources.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PreReq",
                table: "Move",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VideoLink",
                table: "Move",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TrapezeVideos",
                columns: table => new
                {
                    VideoID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Level = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PreReqs = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrapezeVideos", x => x.VideoID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrapezeVideos");

            migrationBuilder.DropColumn(
                name: "PreReq",
                table: "Move");

            migrationBuilder.DropColumn(
                name: "VideoLink",
                table: "Move");
        }
    }
}
