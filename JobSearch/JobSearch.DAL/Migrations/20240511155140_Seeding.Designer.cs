﻿// <auto-generated />
using System;
using JobSearch.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JobSearch.DAL.Migrations
{
    [DbContext(typeof(JobSearchContext))]
    [Migration("20240511155140_Seeding")]
    partial class Seeding
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("JobSearch.DAL.EfClasses.EmploymentType", b =>
                {
                    b.Property<int>("EmploymentTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmploymentTypeId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("EmploymentTypeId");

                    b.ToTable("EmploymentTypes");
                });

            modelBuilder.Entity("JobSearch.DAL.EfClasses.Experience", b =>
                {
                    b.Property<int>("ExperienceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExperienceId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("ExperienceId");

                    b.ToTable("Experiences");
                });

            modelBuilder.Entity("JobSearch.DAL.EfClasses.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("RefreshToken")
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("varchar(256)");

                    b.Property<DateTime?>("RefreshTokenExpiry")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("JobSearch.DAL.EfClasses.Vacancy", b =>
                {
                    b.Property<int>("VacancyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VacancyId"));

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("ntext");

                    b.Property<int>("EmploymentTypeId")
                        .HasColumnType("int");

                    b.Property<int>("ExperienceId")
                        .HasColumnType("int");

                    b.Property<int>("FormatId")
                        .HasColumnType("int");

                    b.Property<bool>("IsPublished")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("PublicationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("VacancyId");

                    b.HasIndex("EmploymentTypeId")
                        .IsUnique();

                    b.HasIndex("ExperienceId")
                        .IsUnique();

                    b.HasIndex("FormatId")
                        .IsUnique();

                    b.ToTable("Vacancies");
                });

            modelBuilder.Entity("JobSearch.DAL.EfClasses.VacancyResponse", b =>
                {
                    b.Property<int>("VacancyResponseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VacancyResponseId"));

                    b.Property<string>("CoverLetter")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("ntext");

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("LName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<byte[]>("Resume")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("varbinary(max)");

                    b.Property<int>("VacancyId")
                        .HasColumnType("int");

                    b.HasKey("VacancyResponseId");

                    b.HasIndex("VacancyId");

                    b.ToTable("VacancyResponses");
                });

            modelBuilder.Entity("JobSearch.DAL.EfClasses.WorkFormat", b =>
                {
                    b.Property<int>("WorkFormatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WorkFormatId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("WorkFormatId");

                    b.ToTable("WorkFormats");
                });

            modelBuilder.Entity("JobSearch.DAL.EfClasses.Vacancy", b =>
                {
                    b.HasOne("JobSearch.DAL.EfClasses.EmploymentType", "EmploymentType")
                        .WithOne()
                        .HasForeignKey("JobSearch.DAL.EfClasses.Vacancy", "EmploymentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobSearch.DAL.EfClasses.Experience", "Experience")
                        .WithOne()
                        .HasForeignKey("JobSearch.DAL.EfClasses.Vacancy", "ExperienceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobSearch.DAL.EfClasses.WorkFormat", "Format")
                        .WithOne()
                        .HasForeignKey("JobSearch.DAL.EfClasses.Vacancy", "FormatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmploymentType");

                    b.Navigation("Experience");

                    b.Navigation("Format");
                });

            modelBuilder.Entity("JobSearch.DAL.EfClasses.VacancyResponse", b =>
                {
                    b.HasOne("JobSearch.DAL.EfClasses.Vacancy", null)
                        .WithMany("VacancyResponses")
                        .HasForeignKey("VacancyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JobSearch.DAL.EfClasses.Vacancy", b =>
                {
                    b.Navigation("VacancyResponses");
                });
#pragma warning restore 612, 618
        }
    }
}