﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThinkQuiz.Domain.SubmittionExamAggregate;

namespace ThinkQuiz.Infrashstructure.Persistence.Configurations
{
    public class SubmittionExamConfigurations : IEntityTypeConfiguration<SubmittionExam>
	{
        public void Configure(EntityTypeBuilder<SubmittionExam> builder)
        {
            builder.ToTable("SubmittionExams");

            builder.HasKey(se => se.Id);

            builder.HasIndex(se => new { se.StudentId, se.ExamId });

            builder.HasOne(se => se.Student)
                .WithMany(student => student.SubmittionExams)
                .HasForeignKey(se => se.StudentId)
                .IsRequired();

            builder.HasOne(se => se.Exam)
                .WithMany(exam => exam.SubmittionExams)
                .HasForeignKey(se => se.ExamId)
                .IsRequired();

            builder.Property(se => se.CreatedAt);

            builder.Property(se => se.UpdatedAt);
        }
    }
}

