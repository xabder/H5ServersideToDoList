﻿// <auto-generated />
using System;
using H5ServersideToDoList.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace H5ServersideToDoList.Migrations.DataDB
{
    [DbContext(typeof(DataDBContext))]
    [Migration("20240411090532_addExtraDatabase")]
    partial class addExtraDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.3");

            modelBuilder.Entity("H5ServersideToDoList.Data.Models.Entities.Cpr", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("CprNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("IdentityId")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserMail")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Cprs");
                });

            modelBuilder.Entity("H5ServersideToDoList.Data.Models.Entities.ToDoItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("IdentityId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TodoItems");
                });
#pragma warning restore 612, 618
        }
    }
}