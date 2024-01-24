using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThinkQuiz.Domain.ExamAggregate;
using ThinkQuiz.Domain.ExamQuestionAggregate;

namespace ThinkQuiz.Infrashstructure.Persistence.Configurations
{
	public class ExamQuestionConfigurations : IEntityTypeConfiguration<ExamQuestion>
	{
        public void Configure(EntityTypeBuilder<ExamQuestion> builder)
        {
            builder.ToTable("ExamQuestions");

            builder.HasKey(examQuestion => examQuestion.Id);

            builder.HasOne<Exam>()
                .WithMany(exam => exam.ExamQuestions)
                .HasForeignKey(examQuestion => examQuestion.ExamId)
                .IsRequired();

            builder.Property(examQuestion => examQuestion.Number);

            builder.Property(examQuestion => examQuestion.Title)
                .HasMaxLength(200);

            builder.Property(examQuestion => examQuestion.Point);

            builder.Property(examQuestion => examQuestion.CorrectAnswer);

            builder.Property(examQuestion => examQuestion.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}

