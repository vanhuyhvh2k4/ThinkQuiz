﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ThinkQuiz.Infrashstructure.Persistence;

#nullable disable

namespace ThinkQuiz.Infrashstructure.Migrations
{
    [DbContext(typeof(ThinkQuizDbContext))]
    partial class ThinkQuizDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ThinkQuiz.Domain.AssignmentAggregate.Assignment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
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

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId", "Name");

                    b.ToTable("Assignments", (string)null);
                });

            modelBuilder.Entity("ThinkQuiz.Domain.ClassAggregate.Class", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("SchoolYear")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("StudentQuantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("double")
                        .HasDefaultValue(0.0);

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId", "Name");

                    b.ToTable("Classes", (string)null);
                });

            modelBuilder.Entity("ThinkQuiz.Domain.ClassAssignmentAggregate.ClassAssignment", b =>
                {
                    b.Property<Guid>("AssignmentId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ClassId")
                        .HasColumnType("char(36)");

                    b.HasKey("AssignmentId", "ClassId");

                    b.HasIndex("ClassId", "AssignmentId");

                    b.ToTable("ClassAssignments", (string)null);
                });

            modelBuilder.Entity("ThinkQuiz.Domain.ClassExamAggregate.ClassExam", b =>
                {
                    b.Property<Guid>("ClassId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ExamId")
                        .HasColumnType("char(36)");

                    b.HasKey("ClassId", "ExamId");

                    b.HasIndex("ExamId");

                    b.HasIndex("ClassId", "ExamId");

                    b.ToTable("ClassExams", (string)null);
                });

            modelBuilder.Entity("ThinkQuiz.Domain.ClassStudentAggregate.ClassStudent", b =>
                {
                    b.Property<Guid>("StudentId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ClassId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("StudentId", "ClassId");

                    b.HasIndex("ClassId");

                    b.HasIndex("StudentId", "ClassId");

                    b.ToTable("ClassStudents", (string)null);
                });

            modelBuilder.Entity("ThinkQuiz.Domain.ExamAggregate.Exam", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
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
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId", "Name");

                    b.ToTable("Exams", (string)null);
                });

            modelBuilder.Entity("ThinkQuiz.Domain.ExamChoiceAggregate.ExamChoice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("ExamChoices", (string)null);
                });

            modelBuilder.Entity("ThinkQuiz.Domain.ExamQuestionAggregate.ExamQuestion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CorrectAnswer")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ExamId")
                        .HasColumnType("char(36)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<double>("Point")
                        .HasColumnType("double");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("ExamId");

                    b.ToTable("ExamQuestions", (string)null);
                });

            modelBuilder.Entity("ThinkQuiz.Domain.StudentAggregate.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Students", (string)null);
                });

            modelBuilder.Entity("ThinkQuiz.Domain.SubmittionAssignmentAggregate.SubmittionAssignment", b =>
                {
                    b.Property<Guid>("AssignmentId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<string>("AnswerUrl")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Comment")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsShowPoint")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.Property<bool>("IsSubmitAgain")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.Property<double?>("Point")
                        .HasColumnType("double");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("AssignmentId", "StudentId", "Id");

                    b.HasIndex("StudentId", "AssignmentId");

                    b.ToTable("SubmittionAssignments", (string)null);
                });

            modelBuilder.Entity("ThinkQuiz.Domain.SubmittionExamAggregate.SubmittionExam", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("ExamId")
                        .HasColumnType("char(36)");

                    b.Property<double?>("Point")
                        .HasColumnType("double");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("ExamId");

                    b.HasIndex("StudentId", "ExamId");

                    b.ToTable("SubmittionExams", (string)null);
                });

            modelBuilder.Entity("ThinkQuiz.Domain.SubmittionExamAnswerAggregate.SubmittionExamAnswer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ChoiceId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("submittionExamId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("submittionExamId", "QuestionId", "ChoiceId");

                    b.ToTable("SubmittionExamAnswers", (string)null);
                });

            modelBuilder.Entity("ThinkQuiz.Domain.TeacherAggregate.Teacher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("SchoolInformation")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Teachers", (string)null);
                });

            modelBuilder.Entity("ThinkQuiz.Domain.UserAggregate.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
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

                    b.Property<bool>("Gender")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("LastLogin")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Phone")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("FullName");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("ThinkQuiz.Domain.AssignmentAggregate.Assignment", b =>
                {
                    b.HasOne("ThinkQuiz.Domain.TeacherAggregate.Teacher", "Teacher")
                        .WithMany("Assignments")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("ThinkQuiz.Domain.ClassAggregate.Class", b =>
                {
                    b.HasOne("ThinkQuiz.Domain.TeacherAggregate.Teacher", "Teacher")
                        .WithMany("Classes")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("ThinkQuiz.Domain.ClassAssignmentAggregate.ClassAssignment", b =>
                {
                    b.HasOne("ThinkQuiz.Domain.AssignmentAggregate.Assignment", "Assignment")
                        .WithMany("ClassAssignments")
                        .HasForeignKey("AssignmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ThinkQuiz.Domain.ClassAggregate.Class", "Class")
                        .WithMany("ClassAssignments")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assignment");

                    b.Navigation("Class");
                });

            modelBuilder.Entity("ThinkQuiz.Domain.ClassExamAggregate.ClassExam", b =>
                {
                    b.HasOne("ThinkQuiz.Domain.ClassAggregate.Class", "Class")
                        .WithMany("ClassExams")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ThinkQuiz.Domain.ExamAggregate.Exam", "Exam")
                        .WithMany("ClassExams")
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Exam");
                });

            modelBuilder.Entity("ThinkQuiz.Domain.ClassStudentAggregate.ClassStudent", b =>
                {
                    b.HasOne("ThinkQuiz.Domain.ClassAggregate.Class", "Class")
                        .WithMany("ClassStudents")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ThinkQuiz.Domain.StudentAggregate.Student", "Student")
                        .WithMany("ClassStudents")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ThinkQuiz.Domain.ExamAggregate.Exam", b =>
                {
                    b.HasOne("ThinkQuiz.Domain.TeacherAggregate.Teacher", "Teacher")
                        .WithMany("Exams")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("ThinkQuiz.Domain.ExamChoiceAggregate.ExamChoice", b =>
                {
                    b.HasOne("ThinkQuiz.Domain.ExamQuestionAggregate.ExamQuestion", "ExamQuestion")
                        .WithMany("ExamChoices")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExamQuestion");
                });

            modelBuilder.Entity("ThinkQuiz.Domain.ExamQuestionAggregate.ExamQuestion", b =>
                {
                    b.HasOne("ThinkQuiz.Domain.ExamAggregate.Exam", "Exam")
                        .WithMany("ExamQuestions")
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exam");
                });

            modelBuilder.Entity("ThinkQuiz.Domain.StudentAggregate.Student", b =>
                {
                    b.HasOne("ThinkQuiz.Domain.UserAggregate.User", "User")
                        .WithOne("Student")
                        .HasForeignKey("ThinkQuiz.Domain.StudentAggregate.Student", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ThinkQuiz.Domain.SubmittionAssignmentAggregate.SubmittionAssignment", b =>
                {
                    b.HasOne("ThinkQuiz.Domain.AssignmentAggregate.Assignment", "Assignment")
                        .WithMany("SubmittionAssignments")
                        .HasForeignKey("AssignmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ThinkQuiz.Domain.StudentAggregate.Student", "Student")
                        .WithMany("SubmittionAssignments")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assignment");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ThinkQuiz.Domain.SubmittionExamAggregate.SubmittionExam", b =>
                {
                    b.HasOne("ThinkQuiz.Domain.ExamAggregate.Exam", "Exam")
                        .WithMany("SubmittionExams")
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ThinkQuiz.Domain.StudentAggregate.Student", "Student")
                        .WithMany("SubmittionExams")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exam");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ThinkQuiz.Domain.SubmittionExamAnswerAggregate.SubmittionExamAnswer", b =>
                {
                    b.HasOne("ThinkQuiz.Domain.SubmittionExamAggregate.SubmittionExam", "SubmittionExam")
                        .WithMany("SubmittionExamAnswers")
                        .HasForeignKey("submittionExamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubmittionExam");
                });

            modelBuilder.Entity("ThinkQuiz.Domain.TeacherAggregate.Teacher", b =>
                {
                    b.HasOne("ThinkQuiz.Domain.UserAggregate.User", "User")
                        .WithOne("Teacher")
                        .HasForeignKey("ThinkQuiz.Domain.TeacherAggregate.Teacher", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ThinkQuiz.Domain.AssignmentAggregate.Assignment", b =>
                {
                    b.Navigation("ClassAssignments");

                    b.Navigation("SubmittionAssignments");
                });

            modelBuilder.Entity("ThinkQuiz.Domain.ClassAggregate.Class", b =>
                {
                    b.Navigation("ClassAssignments");

                    b.Navigation("ClassExams");

                    b.Navigation("ClassStudents");
                });

            modelBuilder.Entity("ThinkQuiz.Domain.ExamAggregate.Exam", b =>
                {
                    b.Navigation("ClassExams");

                    b.Navigation("ExamQuestions");

                    b.Navigation("SubmittionExams");
                });

            modelBuilder.Entity("ThinkQuiz.Domain.ExamQuestionAggregate.ExamQuestion", b =>
                {
                    b.Navigation("ExamChoices");
                });

            modelBuilder.Entity("ThinkQuiz.Domain.StudentAggregate.Student", b =>
                {
                    b.Navigation("ClassStudents");

                    b.Navigation("SubmittionAssignments");

                    b.Navigation("SubmittionExams");
                });

            modelBuilder.Entity("ThinkQuiz.Domain.SubmittionExamAggregate.SubmittionExam", b =>
                {
                    b.Navigation("SubmittionExamAnswers");
                });

            modelBuilder.Entity("ThinkQuiz.Domain.TeacherAggregate.Teacher", b =>
                {
                    b.Navigation("Assignments");

                    b.Navigation("Classes");

                    b.Navigation("Exams");
                });

            modelBuilder.Entity("ThinkQuiz.Domain.UserAggregate.User", b =>
                {
                    b.Navigation("Student");

                    b.Navigation("Teacher");
                });
#pragma warning restore 612, 618
        }
    }
}
