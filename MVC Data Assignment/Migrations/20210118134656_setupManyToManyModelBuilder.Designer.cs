﻿// <auto-generated />
using System;
using MVC_Data_Assignment.Models.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MVC_Data_Assignment.Migrations
{
    [DbContext(typeof(PeopleDbContext))]
    [Migration("20210118134656_setupManyToManyModelBuilder")]
    partial class setupManyToManyModelBuilder
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MVC_Data_Assignment.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CountryID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryID");

                    b.ToTable("CityList");
                });

            modelBuilder.Entity("MVC_Data_Assignment.Models.Country", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("CountryList");
                });

            modelBuilder.Entity("MVC_Data_Assignment.Models.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CountryID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryID");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("MVC_Data_Assignment.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNum")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("PeopleList");
                });

            modelBuilder.Entity("MVC_Data_Assignment.Models.PersonLanguage", b =>
                {
                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.HasKey("PersonId", "LanguageId");

                    b.HasIndex("LanguageId");

                    b.ToTable("PersonLanguage");
                });

            modelBuilder.Entity("MVC_Data_Assignment.Models.City", b =>
                {
                    b.HasOne("MVC_Data_Assignment.Models.Country", "Country")
                        .WithMany("CitiesList")
                        .HasForeignKey("CountryID");
                });

            modelBuilder.Entity("MVC_Data_Assignment.Models.Language", b =>
                {
                    b.HasOne("MVC_Data_Assignment.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryID");
                });

            modelBuilder.Entity("MVC_Data_Assignment.Models.Person", b =>
                {
                    b.HasOne("MVC_Data_Assignment.Models.City", "City")
                        .WithMany("CityPeopleList")
                        .HasForeignKey("CityId");
                });

            modelBuilder.Entity("MVC_Data_Assignment.Models.PersonLanguage", b =>
                {
                    b.HasOne("MVC_Data_Assignment.Models.Language", "Language")
                        .WithMany("Speakers")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVC_Data_Assignment.Models.Person", "Person")
                        .WithMany("Languages")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
