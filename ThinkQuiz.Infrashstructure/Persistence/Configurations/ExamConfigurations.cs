using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThinkQuiz.Domain.ExamAggregate;
using ThinkQuiz.Domain.TeacherAggregate;

namespace ThinkQuiz.Infrashstructure.Persistence.Configurations
{
	public class ExamConfigurations : IEntityTypeConfiguration<Exam>
	{
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder.ToTable("Exams");

            builder.HasKey(exam => exam.Id);

            builder.HasOne(exam => exam.Teacher)
                .WithMany(teacher => teacher.Exams)
                .HasForeignKey(exam => exam.TeacherId)
                .IsRequired();

            builder.Property(exam => exam.Name)
                .HasMaxLength(100);

            builder.Property(exam => exam.Password)
                .IsRequired(false);

            builder.Property(exam => exam.IsPublish)
                .HasDefaultValue(false);

            builder.Property(exam => exam.IsWrap)
                .HasDefaultValue(false);

            builder.Property(exam => exam.IsShowResult)
                .HasDefaultValue(false);

            builder.Property(exam => exam.IsShowPoint)
                .HasDefaultValue(false);

            builder.Property(exam => exam.IsDeleted)
                .HasDefaultValue(false);

            builder.Property(exam => exam.LimitAttemptNumber)
                .HasDefaultValue(1);

            builder.Property(exam => exam.StartTime);

            builder.Property(exam => exam.EndTime);

            builder.Property(exam => exam.Duration);

            builder.Property(exam => exam.CreatedAt);

            builder.Property(exam => exam.UpdatedAt);
        }
    }
}

