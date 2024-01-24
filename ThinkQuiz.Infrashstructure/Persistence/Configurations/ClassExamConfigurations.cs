using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThinkQuiz.Domain.ClassExamAggregate;

namespace ThinkQuiz.Infrashstructure.Persistence.Configurations
{
    public class ClassExamConfigurations : IEntityTypeConfiguration<ClassExam>
	{
        public void Configure(EntityTypeBuilder<ClassExam> builder)
        {
            builder.ToTable("ClassExams");

            builder.HasKey(ce => new { ce.ClassId, ce.ExamId });

            builder.HasOne(ce => ce.Class)
                .WithMany(c => c.ClassExams)
                .HasForeignKey(ce => ce.ClassId)
                .IsRequired();

            builder.HasOne(ce => ce.Exam)
                .WithMany(exam => exam.ClassExams)
                .HasForeignKey(ce => ce.ExamId)
                .IsRequired();
        }
    }
}

