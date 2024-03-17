﻿// <auto-generated />
using CRM.WEB.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CRM.WEB.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240317150340_Mig")]
    partial class Mig
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CRM.WEB.Models.Entyties.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("CRM.WEB.Models.Entyties.Course_Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Course_Id")
                        .HasColumnType("int");

                    b.Property<int>("Teacher_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Course_Id");

                    b.HasIndex("Teacher_Id");

                    b.ToTable("Course_Teacher");
                });

            modelBuilder.Entity("CRM.WEB.Models.Entyties.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Course_Id")
                        .HasColumnType("int");

                    b.Property<int>("Group_Id")
                        .HasColumnType("int");

                    b.Property<int>("Teacher_Id")
                        .HasColumnType("int");

                    b.Property<string>("Time")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Weekday")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Сlassroom_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Course_Id")
                        .IsUnique();

                    b.HasIndex("Group_Id")
                        .IsUnique();

                    b.HasIndex("Teacher_Id")
                        .IsUnique();

                    b.HasIndex("Сlassroom_Id")
                        .IsUnique();

                    b.ToTable("Event");
                });

            modelBuilder.Entity("CRM.WEB.Models.Entyties.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("CRM.WEB.Models.Entyties.Group_Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Group_Id")
                        .HasColumnType("int");

                    b.Property<int>("Student_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Group_Id");

                    b.HasIndex("Student_Id");

                    b.ToTable("Group_Student");
                });

            modelBuilder.Entity("CRM.WEB.Models.Entyties.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FIO")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("CRM.WEB.Models.Entyties.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FIO")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teacher");
                });

            modelBuilder.Entity("CRM.WEB.Models.Entyties.Сlassroom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Сlassroom");
                });

            modelBuilder.Entity("CRM.WEB.Models.Entyties.Course_Teacher", b =>
                {
                    b.HasOne("CRM.WEB.Models.Entyties.Course", "Course_")
                        .WithMany("Course_Teachers")
                        .HasForeignKey("Course_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CRM.WEB.Models.Entyties.Teacher", "Teacher_")
                        .WithMany("Course_Teachers")
                        .HasForeignKey("Teacher_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course_");

                    b.Navigation("Teacher_");
                });

            modelBuilder.Entity("CRM.WEB.Models.Entyties.Event", b =>
                {
                    b.HasOne("CRM.WEB.Models.Entyties.Course", "Course")
                        .WithOne("Event")
                        .HasForeignKey("CRM.WEB.Models.Entyties.Event", "Course_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CRM.WEB.Models.Entyties.Group", "Group")
                        .WithOne("Event")
                        .HasForeignKey("CRM.WEB.Models.Entyties.Event", "Group_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CRM.WEB.Models.Entyties.Teacher", "Teacher")
                        .WithOne("Event")
                        .HasForeignKey("CRM.WEB.Models.Entyties.Event", "Teacher_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CRM.WEB.Models.Entyties.Сlassroom", "Сlassroom")
                        .WithOne("Event")
                        .HasForeignKey("CRM.WEB.Models.Entyties.Event", "Сlassroom_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Group");

                    b.Navigation("Teacher");

                    b.Navigation("Сlassroom");
                });

            modelBuilder.Entity("CRM.WEB.Models.Entyties.Group_Student", b =>
                {
                    b.HasOne("CRM.WEB.Models.Entyties.Group", "Group_")
                        .WithMany("Group_Students")
                        .HasForeignKey("Group_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CRM.WEB.Models.Entyties.Student", "Student_")
                        .WithMany("Group_Students")
                        .HasForeignKey("Student_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group_");

                    b.Navigation("Student_");
                });

            modelBuilder.Entity("CRM.WEB.Models.Entyties.Course", b =>
                {
                    b.Navigation("Course_Teachers");

                    b.Navigation("Event")
                        .IsRequired();
                });

            modelBuilder.Entity("CRM.WEB.Models.Entyties.Group", b =>
                {
                    b.Navigation("Event")
                        .IsRequired();

                    b.Navigation("Group_Students");
                });

            modelBuilder.Entity("CRM.WEB.Models.Entyties.Student", b =>
                {
                    b.Navigation("Group_Students");
                });

            modelBuilder.Entity("CRM.WEB.Models.Entyties.Teacher", b =>
                {
                    b.Navigation("Course_Teachers");

                    b.Navigation("Event")
                        .IsRequired();
                });

            modelBuilder.Entity("CRM.WEB.Models.Entyties.Сlassroom", b =>
                {
                    b.Navigation("Event")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
