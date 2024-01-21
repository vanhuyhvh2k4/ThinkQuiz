﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ThinkQuiz.Infrashstructure.Persistence;

#nullable disable

namespace ThinkQuiz.Infrashstructure.Migrations
{
    [DbContext(typeof(ThinkQuizDbContext))]
    [Migration("20240121085445_StudentCreate")]
    partial class StudentCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ThinkQuiz.Domain.StudentAggregate.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("Students", (string)null);
                });

            modelBuilder.Entity("ThinkQuiz.Domain.TeacherAggregate.Teacher", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("SchoolInforamtion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("Teachers", (string)null);
                });

            modelBuilder.Entity("ThinkQuiz.Domain.UserAggregate.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateOnly?>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<bool?>("Gender")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("LastLogin")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("ThinkQuiz.Domain.StudentAggregate.Student", b =>
                {
                    b.OwnsMany("ThinkQuiz.Domain.ClassAggregate.ValueObjects.ClassId", "ClassIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            b1.Property<Guid>("StudentId")
                                .HasColumnType("char(36)");

                            b1.Property<Guid>("Value")
                                .HasColumnType("char(36)")
                                .HasColumnName("ClassId");

                            b1.HasKey("Id");

                            b1.HasIndex("StudentId");

                            b1.ToTable("StudentClasseIds", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("StudentId");
                        });

                    b.OwnsMany("ThinkQuiz.Domain.SubmittionAssignmentAggregate.ValueObjects.SubmittionAssignmentId", "SubmittionAssignmentIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            b1.Property<Guid>("StudentId")
                                .HasColumnType("char(36)");

                            b1.Property<Guid>("Value")
                                .HasColumnType("char(36)")
                                .HasColumnName("SubmittionAssignmentId");

                            b1.HasKey("Id");

                            b1.HasIndex("StudentId");

                            b1.ToTable("StudentSubmittionAssignmentIds", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("StudentId");
                        });

                    b.OwnsMany("ThinkQuiz.Domain.SubmittionExamAggregate.ValueObjects.SubmittionExamId", "SubmittionExamIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            b1.Property<Guid>("StudentId")
                                .HasColumnType("char(36)");

                            b1.Property<Guid>("Value")
                                .HasColumnType("char(36)")
                                .HasColumnName("SubmittionExamId");

                            b1.HasKey("Id");

                            b1.HasIndex("StudentId");

                            b1.ToTable("StudentSubmittionExamIds", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("StudentId");
                        });

                    b.Navigation("ClassIds");

                    b.Navigation("SubmittionAssignmentIds");

                    b.Navigation("SubmittionExamIds");
                });

            modelBuilder.Entity("ThinkQuiz.Domain.TeacherAggregate.Teacher", b =>
                {
                    b.OwnsMany("ThinkQuiz.Domain.AssignmentAggregate.ValueObjects.AssignmentId", "AssignmentIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            b1.Property<Guid>("AuthorId")
                                .HasColumnType("char(36)");

                            b1.Property<Guid>("Value")
                                .HasColumnType("char(36)")
                                .HasColumnName("AssignmentId");

                            b1.HasKey("Id");

                            b1.HasIndex("AuthorId");

                            b1.ToTable("TeacherAssignmentIds", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("AuthorId");
                        });

                    b.OwnsMany("ThinkQuiz.Domain.ExamAggregate.ValueObjects.ExamId", "ExamIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            b1.Property<Guid>("AuthorId")
                                .HasColumnType("char(36)");

                            b1.Property<Guid>("Value")
                                .HasColumnType("char(36)")
                                .HasColumnName("ExamId");

                            b1.HasKey("Id");

                            b1.HasIndex("AuthorId");

                            b1.ToTable("TeacherExamIds", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("AuthorId");
                        });

                    b.OwnsMany("ThinkQuiz.Domain.ClassAggregate.ValueObjects.ClassId", "ClassIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            b1.Property<Guid>("TeacherId")
                                .HasColumnType("char(36)");

                            b1.Property<Guid>("Value")
                                .HasColumnType("char(36)")
                                .HasColumnName("ClassId");

                            b1.HasKey("Id");

                            b1.HasIndex("TeacherId");

                            b1.ToTable("TeacherClassIds", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("TeacherId");
                        });

                    b.Navigation("AssignmentIds");

                    b.Navigation("ClassIds");

                    b.Navigation("ExamIds");
                });
#pragma warning restore 612, 618
        }
    }
}