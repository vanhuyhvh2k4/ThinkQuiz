using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThinkQuiz.Domain.ExamAggregate;
using ThinkQuiz.Domain.StudentAggregate;
using ThinkQuiz.Domain.SubmittionExamAggregate;

namespace ThinkQuiz.Infrashstructure.Persistence.Configurations
{
    public class SubmittionExamConfigurations : IEntityTypeConfiguration<SubmittionExam>
	{
        public void Configure(EntityTypeBuilder<SubmittionExam> builder)
        {
            builder.ToTable("SubmittionExams");

            builder.HasKey(se => new { se.Id, se.StudentId, se.ExamId });

            builder.HasOne<Student>()
                .WithMany(student => student.SubmittionExams)
                .HasForeignKey(se => se.StudentId)
                .IsRequired();

            builder.HasOne<Exam>()
                .WithMany(exam => exam.SubmittionExams)
                .HasForeignKey(se => se.ExamId)
                .IsRequired();

            builder.Property(se => se.CreatedAt);

            builder.Property(se => se.UpdatedAt);
        }
    }
}

