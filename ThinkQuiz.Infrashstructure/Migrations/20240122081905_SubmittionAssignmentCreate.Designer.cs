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
    [Migration("20240122081905_SubmittionAssignmentCreate")]
    partial class SubmittionAssignmentCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ThinkQuiz.Domain.AssignmentAggregate.Assignment", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Content")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FileUrl")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Assignments", (string)null);
                });

            modelBuilder.Entity("ThinkQuiz.Domain.ExamAggregate.Exam", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.Property<bool>("IsPublish")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.Property<bool>("IsShowPoint")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.Property<bool>("IsShowResult")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.Property<bool>("IsWrap")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.Property<int>("LimitAttemptNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Password")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Exams", (string)null);
                });

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

            modelBuilder.Entity("ThinkQuiz.Domain.SubmittionAssignmentAggregate.SubmittionAssignment", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<string>("AnswerUrl")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<Guid>("AssignmentId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Comment")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsShowPoint")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsSubmitAgain")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.Property<double?>("Point")
                        .HasColumnType("double");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("SubmittionAssignments", (string)null);
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

            modelBuilder.Entity("ThinkQuiz.Domain.AssignmentAggregate.Assignment", b =>
                {
                    b.OwnsMany("ThinkQuiz.Domain.ClassAggregate.ValueObjects.ClassId", "ClassIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            b1.Property<Guid>("AssignmentId")
                                .HasColumnType("char(36)");

                            b1.Property<Guid>("Value")
                                .HasColumnType("char(36)")
                                .HasColumnName("ClassId");

                            b1.HasKey("Id");

                            b1.HasIndex("AssignmentId");

                            b1.ToTable("AssignmentClassIds", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("AssignmentId");
                        });

                    b.OwnsMany("ThinkQuiz.Domain.SubmittionAssignmentAggregate.ValueObjects.SubmittionAssignmentId", "SubmittionAssignmentIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            b1.Property<Guid>("AssignmentId")
                                .HasColumnType("char(36)");

                            b1.Property<Guid>("Value")
                                .HasColumnType("char(36)")
                                .HasColumnName("SubmittionId");

                            b1.HasKey("Id");

                            b1.HasIndex("AssignmentId");

                            b1.ToTable("AssignmentSubmittionIds", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("AssignmentId");
                        });

                    b.Navigation("ClassIds");

                    b.Navigation("SubmittionAssignmentIds");
                });

            modelBuilder.Entity("ThinkQuiz.Domain.ExamAggregate.Exam", b =>
                {
                    b.OwnsMany("ThinkQuiz.Domain.ExamAggregate.Entities.Question", "Questions", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("char(36)");

                            b1.Property<Guid>("CorrectAnswer")
                                .HasColumnType("char(36)");

                            b1.Property<Guid>("ExamId")
                                .HasColumnType("char(36)");

                            b1.Property<bool>("IsDeleted")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("tinyint(1)")
                                .HasDefaultValue(false);

                            b1.Property<int>("Number")
                                .HasColumnType("int");

                            b1.Property<double>("Point")
                                .HasColumnType("double");

                            b1.Property<string>("Title")
                                .IsRequired()
                                .HasMaxLength(200)
                                .HasColumnType("varchar(200)");

                            b1.HasKey("Id");

                            b1.HasIndex("ExamId");

                            b1.ToTable("ExamQuestions", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("ExamId");

                            b1.OwnsMany("ThinkQuiz.Domain.ExamAggregate.Entities.Choice", "Choices", b2 =>
                                {
                                    b2.Property<Guid>("Id")
                                        .HasColumnType("char(36)");

                                    b2.Property<bool>("IsDeleted")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("tinyint(1)")
                                        .HasDefaultValue(false);

                                    b2.Property<int>("Number")
                                        .HasColumnType("int");

                                    b2.Property<Guid>("QuestionId")
                                        .HasColumnType("char(36)");

                                    b2.Property<string>("Title")
                                        .IsRequired()
                                        .HasMaxLength(200)
                                        .HasColumnType("varchar(200)");

                                    b2.HasKey("Id");

                                    b2.HasIndex("QuestionId");

                                    b2.ToTable("ExamChoices", (string)null);

                                    b2.WithOwner()
                                        .HasForeignKey("QuestionId");
                                });

                            b1.Navigation("Choices");
                        });

                    b.OwnsMany("ThinkQuiz.Domain.ClassAggregate.ValueObjects.ClassId", "ClassIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            b1.Property<Guid>("ExamId")
                                .HasColumnType("char(36)");

                            b1.Property<Guid>("Value")
                                .HasColumnType("char(36)")
                                .HasColumnName("ClassId");

                            b1.HasKey("Id");

                            b1.HasIndex("ExamId");

                            b1.ToTable("ExamClassIds", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("ExamId");
                        });

                    b.OwnsMany("ThinkQuiz.Domain.SubmittionExamAggregate.ValueObjects.SubmittionExamId", "SubmittionExamIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            b1.Property<Guid>("ExamId")
                                .HasColumnType("char(36)");

                            b1.Property<Guid>("Value")
                                .HasColumnType("char(36)")
                                .HasColumnName("SubmittionId");

                            b1.HasKey("Id");

                            b1.HasIndex("ExamId");

                            b1.ToTable("ExamSubmittionIds", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("ExamId");
                        });

                    b.Navigation("ClassIds");

                    b.Navigation("Questions");

                    b.Navigation("SubmittionExamIds");
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