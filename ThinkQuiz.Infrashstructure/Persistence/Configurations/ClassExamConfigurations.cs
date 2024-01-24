using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThinkQuiz.Domain.ClassAggregate;
using ThinkQuiz.Domain.ClassExamAggregate;
using ThinkQuiz.Domain.ExamAggregate;

namespace ThinkQuiz.Infrashstructure.Persistence.Configurations
{
	public class ClassExamConfigurations : IEntityTypeConfiguration<ClassExam>
	{
        public void Configure(EntityTypeBuilder<ClassExam> builder)
        {
            builder.ToTable("ClassExam");

            builder.HasKey(ce => new { ce.ClassId, ce.ExamId });

            builder.HasOne<Class>()
                .WithMany(c => c.ClassExams)
                .HasForeignKey(ce => ce.ClassId)
                .IsRequired();

            builder.HasOne<Exam>()
                .WithMany(exam => exam.ClassExams)
                .HasForeignKey(ce => ce.ExamId)
                .IsRequired();
        }
    }
}

