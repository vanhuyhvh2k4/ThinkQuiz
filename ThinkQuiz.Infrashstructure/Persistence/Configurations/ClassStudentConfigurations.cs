using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThinkQuiz.Domain.ClassAggregate;
using ThinkQuiz.Domain.ClassStudentAggregate;
using ThinkQuiz.Domain.StudentAggregate;

namespace ThinkQuiz.Infrashstructure.Persistence.Configurations
{
	public class ClassStudentConfigurations : IEntityTypeConfiguration<ClassStudent>
	{
        public void Configure(EntityTypeBuilder<ClassStudent> builder)
        {
            builder.ToTable("ClassStudents");

            builder.HasKey(cs => new { cs.StudentId, cs.ClassId });

            builder.HasOne<Student>()
                .WithMany(student => student.ClassStudents)
                .HasForeignKey(cs => cs.StudentId)
                .IsRequired();

            builder.HasOne<Class>()
                .WithMany(c => c.ClassStudents)
                .HasForeignKey(cs => cs.ClassId)
                .IsRequired();

            builder.Property(cs => cs.CreatedAt);

            builder.Property(cs => cs.UpdatedAt);
        }
    }
}

