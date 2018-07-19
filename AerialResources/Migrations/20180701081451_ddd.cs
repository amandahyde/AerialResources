using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AerialResources.Migrations
{
    public partial class ddd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DuoVideos",
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
                    table.PrimaryKey("PK_DuoVideos", x => x.VideoID);
                });

            migrationBuilder.CreateTable(
                name: "LyraVideos",
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
                    table.PrimaryKey("PK_LyraVideos", x => x.VideoID);
                });

            migrationBuilder.CreateTable(
                name: "RopeVideos",
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
                    table.PrimaryKey("PK_RopeVideos", x => x.VideoID);
                });

            migrationBuilder.CreateTable(
                name: "SilksVideos",
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
                    table.PrimaryKey("PK_SilksVideos", x => x.VideoID);
                });

            migrationBuilder.CreateTable(
                name: "SlingVideos",
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
                    table.PrimaryKey("PK_SlingVideos", x => x.VideoID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DuoVideos");

            migrationBuilder.DropTable(
                name: "LyraVideos");

            migrationBuilder.DropTable(
                name: "RopeVideos");

            migrationBuilder.DropTable(
                name: "SilksVideos");

            migrationBuilder.DropTable(
                name: "SlingVideos");
        }
    }
}
