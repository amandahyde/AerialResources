﻿// <auto-generated />
using AerialResources.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace AerialResources.Migrations
{
    [DbContext(typeof(AerialResourcesContext))]
    [Migration("20180610234353_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("AerialResources.Models.Course", b =>
                {
                    b.Property<int>("CourseID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("Level");

                    b.Property<string>("Name");

                    b.HasKey("CourseID");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("AerialResources.Models.Move", b =>
                {
                    b.Property<int>("MoveID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CourseID");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("MoveID");

                    b.ToTable("Move");
                });
#pragma warning restore 612, 618
        }
    }
}
